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

        public AutenticacaoUseCase(IUsuarioRepository usuarioRepository, IAutenticacaoMultifatorService autenticacaoMultifatorService)
        {
            _usuarioRepository = usuarioRepository;
            _autenticacaoMultifatorService = autenticacaoMultifatorService;
        }

        public async Task<AutenticacaoOutput> IniciarAutenticacao(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorCredenciais(email, senha);

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
