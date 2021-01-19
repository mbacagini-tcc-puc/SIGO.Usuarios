using NSubstitute;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator;
using SIGO.Usuarios.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Application
{
    public class ConfirmacaoMultifatorUseCaseTests
    {
        private readonly ConfirmacaoMultifatorUseCase _confirmacaoMultifatorUseCase;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthTokenService _authTokenService;

        private const int UsuarioId = 292929;
        private const string CodigoVerificacao = "204049";

        public ConfirmacaoMultifatorUseCaseTests()
        {
            _usuarioRepository = Substitute.For<IUsuarioRepository>();
            _authTokenService = Substitute.For<IAuthTokenService>();
            _confirmacaoMultifatorUseCase = new ConfirmacaoMultifatorUseCase(_usuarioRepository, _authTokenService);
        }

        [Fact]
        public async Task DeveRetornarNullSeCodigoInvalido()
        {
            // arrange
            var usuario = new Usuario
            {
                CodigoVerificacao = "123456"
            };

            _usuarioRepository.ObterUsuarioPorId(UsuarioId).Returns(usuario);

            // act 
            var resultado = await _confirmacaoMultifatorUseCase.FinalizarAutenticacao(UsuarioId, CodigoVerificacao);

            // arrange
            Assert.Null(resultado);
        }


        [Fact]
        public async Task DeveRetornarNullSeCodigoExpirado()
        {
            // arrange
            var usuario = new Usuario
            {
                CodigoVerificacao = CodigoVerificacao,
                ExpiracaoCodigoVerificacao = DateTime.UtcNow.AddMinutes(-6)
            };

            _usuarioRepository.ObterUsuarioPorId(UsuarioId).Returns(usuario);

            // act 
            var resultado = await _confirmacaoMultifatorUseCase.FinalizarAutenticacao(UsuarioId, CodigoVerificacao);

            // arrange
            Assert.Null(resultado);
        }

        [Fact]
        public async Task DeveFinalizarAutenticacao()
        {
            // arrange
            var usuario = new Usuario
            {
                Id = UsuarioId,
                Email = "email@teste.com",
                CodigoVerificacao = CodigoVerificacao,
                ExpiracaoCodigoVerificacao = DateTime.UtcNow.AddMinutes(2),
                Modulos = new List<Modulo>
                 {
                     new Modulo { Nome = "consultorias-assesorias" },
                     new Modulo { Nome = "normas" }
                 }
            };

            var token = "access-token";
            Usuario usuarioAtualizado = null;

            await _usuarioRepository.AtualizarUsuario(Arg.Do<Usuario>(recebido => usuarioAtualizado = recebido));

            _usuarioRepository.ObterUsuarioPorId(UsuarioId).Returns(usuario);
            _authTokenService.GerarToken(usuario.Id, usuario.Email).Returns(token);

            // act 
            var resultado = await _confirmacaoMultifatorUseCase.FinalizarAutenticacao(UsuarioId, CodigoVerificacao);

            // arrange
            Assert.Equal(token, resultado.AccessToken);
            Assert.Equal("consultorias-assesorias", resultado.Modulos[0]);
            Assert.Equal("normas", resultado.Modulos[1]);
            Assert.Null(usuarioAtualizado.CodigoVerificacao);
            Assert.Null(usuarioAtualizado.ExpiracaoCodigoVerificacao);
        }
    }
}
