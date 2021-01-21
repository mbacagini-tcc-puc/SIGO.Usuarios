using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using System;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.Autenticacao
{
    public class AutenticacaoUseCase : IAutenticacaoUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoMultifatorService _autenticacaoMultifatorService;
        private readonly IHashService _hashService;

        public AutenticacaoUseCase(IUsuarioRepository usuarioRepository, IAutenticacaoMultifatorService autenticacaoMultifatorService, IHashService hashService)
        {
            _usuarioRepository = usuarioRepository;
            _autenticacaoMultifatorService = autenticacaoMultifatorService;
            _hashService = hashService;
        }

        public async Task<AutenticacaoOutput> IniciarAutenticacao(string email, string senha)
        {
            var hashSenha = _hashService.Hash(senha);
            var hashEmail = _hashService.Hash(email);
            var usuario = await _usuarioRepository.ObterUsuarioPorCredenciais(hashEmail, hashSenha);

            if(usuario == null)
            {
                return null;
            }

            usuario.CodigoVerificacao = GerarCodigoVerificacao();
            usuario.ExpiracaoCodigoVerificacao = DateTime.UtcNow.AddMinutes(5);
            usuario.DataAlteracao = DateTime.UtcNow;

            await _usuarioRepository.AtualizarUsuario(usuario);
            await _autenticacaoMultifatorService.EnviarConfirmacaoMultifator(usuario.Celular, usuario.CodigoVerificacao);

            return new AutenticacaoOutput
            {
                 UsuarioId = usuario.Id,
                 FinalCelular =  ObterFinalCelular(usuario.Celular)
            };
        }

        private static string GerarCodigoVerificacao()
        {
            return new Random().Next(100000, 999999).ToString();
        }

        private static string ObterFinalCelular(string celular)
        {
            return celular.Substring(celular.Length - 4);
        }
    }
}
