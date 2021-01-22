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
        private readonly ICriptografiaService _criptografiaService;

        public AutenticacaoUseCase(IUsuarioRepository usuarioRepository,
                                   IAutenticacaoMultifatorService autenticacaoMultifatorService,
                                   IHashService hashService, 
                                   ICriptografiaService criptografiaService)
        {
            _usuarioRepository = usuarioRepository;
            _autenticacaoMultifatorService = autenticacaoMultifatorService;
            _hashService = hashService;
            _criptografiaService = criptografiaService;
        }

        public async Task<AutenticacaoOutput> IniciarAutenticacao(string email, string senha)
        {
            var hashSenha = _hashService.Hash(senha);
            var emailCriptografado = _criptografiaService.Criptografar(email);
            var usuario = await _usuarioRepository.ObterUsuarioPorCredenciais(emailCriptografado, hashSenha);

            if(usuario == null)
            {
                return null;
            }

            usuario.CodigoVerificacao = GerarCodigoVerificacao();
            usuario.ExpiracaoCodigoVerificacao = DateTime.UtcNow.AddMinutes(5);
            usuario.DataAlteracao = DateTime.UtcNow;

            await _usuarioRepository.AtualizarUsuario(usuario);

            var numeroCelular = _criptografiaService.Descriptografar(usuario.Celular);

            await _autenticacaoMultifatorService.EnviarConfirmacaoMultifator(numeroCelular, usuario.CodigoVerificacao);

            return new AutenticacaoOutput
            {
                 UsuarioId = usuario.Id,
                 FinalCelular =  ObterFinalCelular(numeroCelular)
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
