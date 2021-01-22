using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.CriacaoUsuario
{
    public class CriacaoUsuarioUseCase : ICriacaoUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHashService _hashService;
        private readonly ICriptografiaService _criptografiaService;

        public CriacaoUsuarioUseCase(IUsuarioRepository usuarioRepository, IHashService hashService, ICriptografiaService criptografiaService)
        {
            _usuarioRepository = usuarioRepository;
            _hashService = hashService;
            _criptografiaService = criptografiaService;
        }

        public async Task<int> CriarUsuario(CriacaoUsuarioInput usuarioInput)
        {
            var email = _criptografiaService.Criptografar(usuarioInput.Email);
            var celular = _criptografiaService.Criptografar(usuarioInput.Celular);
            var senha = _hashService.Hash(usuarioInput.Senha);
            var usuario = new Usuario
            {
                 Nome = usuarioInput.Nome,
                 Email = email,
                 Senha = senha,
                 Celular = celular,
                 DataInclusao = DateTime.UtcNow
            };

            usuario.Modulos = usuarioInput.Modulos.Select(moduloId => new UsuarioModulo
            {
                ModuloId = moduloId,
                Usuario = usuario,
                DataInclusao = DateTime.UtcNow
            }).ToList();

            await _usuarioRepository.InserirUsuario(usuario);

            return usuario.Id;
        }
    }
}
