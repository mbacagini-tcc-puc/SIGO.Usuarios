using NSubstitute;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.UseCases.Autenticacao;
using SIGO.Usuarios.Entities;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Application
{
    public class AutenticacaoUseCaseTests
    {
        private readonly AutenticacaoUseCase _autenticacaoUseCase;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAutenticacaoMultifatorService _autenticacaoMultifatorService;
        private readonly IHashService _hashService;
        private readonly ICriptografiaService _criptografiaService;

        private const string Email = "teste@teste.com";
        private const string EmailCriptografado = "AC4DAD48D78AA4D8A4D4D7A7D4";
        private const string Senha = "123456";
        private const string HashSenha = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413";
        
        public AutenticacaoUseCaseTests()
        {
            _usuarioRepository = Substitute.For<IUsuarioRepository>();
            _autenticacaoMultifatorService = Substitute.For<IAutenticacaoMultifatorService>();
            _hashService = Substitute.For<IHashService>();
            _criptografiaService = Substitute.For<ICriptografiaService>();
            _autenticacaoUseCase = new AutenticacaoUseCase(_usuarioRepository, _autenticacaoMultifatorService, _hashService, _criptografiaService);
            _criptografiaService.Criptografar(Email).Returns(EmailCriptografado);
            _hashService.Hash(Senha).Returns(HashSenha);
        }

        [Fact]
        public async Task DeveRetornarNullSeNaoEncontrarUsuario()
        {
            // arrange
            _usuarioRepository.ObterUsuarioPorCredenciais(EmailCriptografado, HashSenha).Returns((Usuario) null);

            // act
            var resultado = await _autenticacaoUseCase.IniciarAutenticacao(Email, Senha);

            // assert
            Assert.Null(resultado);
        }

        [Fact]
        public async Task DeveRetornarCodigoVerificacao()
        {
            // arrange

            var id = 100303;
            var celularCriptografado = "A8D5898D4A4D4D74D78";
            var celular = "1191921228";
            var usuario = new Usuario
            {
                Id = id,
                Celular = celularCriptografado
            };

            _criptografiaService.Descriptografar(celularCriptografado).Returns(celular);
            _usuarioRepository.ObterUsuarioPorCredenciais(EmailCriptografado, HashSenha).Returns(usuario);

            var codigoVerificacaoEnviado = string.Empty;
            var numeroCelularCodigoEnviado = string.Empty;
            Usuario usuarioAtualizado = null;

            await _autenticacaoMultifatorService.EnviarConfirmacaoMultifator(
                 Arg.Do<string>(recebido => numeroCelularCodigoEnviado = recebido),
                 Arg.Do<string>(recebido => codigoVerificacaoEnviado = recebido));

            await _usuarioRepository.AtualizarUsuario(Arg.Do<Usuario>(recebido => usuarioAtualizado = recebido));

            // act
            var resultado = await _autenticacaoUseCase.IniciarAutenticacao(Email, Senha);

            // assert
            Assert.Equal(id, resultado.UsuarioId);
            Assert.Equal("1228", resultado.FinalCelular);
            Assert.Equal(celular, numeroCelularCodigoEnviado);
            Assert.True(Regex.IsMatch(codigoVerificacaoEnviado, "[0-9]{6}"), "Código de verificação gerado incorretamente");
            Assert.Equal(codigoVerificacaoEnviado, usuarioAtualizado.CodigoVerificacao);
            Assert.NotNull(usuarioAtualizado.DataAlteracao);
            Assert.NotNull(usuarioAtualizado.ExpiracaoCodigoVerificacao);
        }
    }
}
