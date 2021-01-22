using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.TransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator
{
    public class ConfirmacaoMultifatorUseCase : IConfirmacaoMultifatorUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthTokenService _authTokenService;
        private readonly ICriptografiaService _criptografiaService;

        public ConfirmacaoMultifatorUseCase(IUsuarioRepository usuarioRepository, IAuthTokenService authTokenService, ICriptografiaService criptografiaService)
        {
            _usuarioRepository = usuarioRepository;
            _authTokenService = authTokenService;
            _criptografiaService = criptografiaService;
        }

        public async Task<ConfirmacaoAutenticacaoOutput> FinalizarAutenticacao(int usuarioId, string codigoVerificacao)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorId(usuarioId);

            if (usuario.CodigoVerificacao != codigoVerificacao || DateTime.UtcNow > usuario.ExpiracaoCodigoVerificacao)
            {
                return null;
            }

            usuario.CodigoVerificacao = null;
            usuario.ExpiracaoCodigoVerificacao = null;

            await _usuarioRepository.AtualizarUsuario(usuario);

            var email = _criptografiaService.Descriptografar(usuario.Email);
            var celular = _criptografiaService.Descriptografar(usuario.Celular);
            var token = _authTokenService.GerarToken(new ClaimsInfo
            {
                UsuarioId = usuario.Id,
                Nome = usuario.Nome,
                Email = email,
                Celular = celular,
                Perfil = usuario.UsuarioExterno ? "Usuário Externo" : "Usuário Interno"
            });

            var modulosPermitidos = usuario.Modulos.Select(mod => mod.Modulo.Nome).ToArray();

            return new ConfirmacaoAutenticacaoOutput
            {
                AccessToken = token,
                Modulos = modulosPermitidos
            };
        }
    }
}
