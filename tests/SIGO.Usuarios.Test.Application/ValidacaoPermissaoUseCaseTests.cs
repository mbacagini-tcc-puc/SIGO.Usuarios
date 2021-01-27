using NSubstitute;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.UseCases.ValidacaoPermissao;
using SIGO.Usuarios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Application
{
    public class ValidacaoPermissaoUseCaseTests
    {
        private readonly ValidacaoPermissaoUseCase _validacaoPermissaoUseCase;
        private readonly IUsuarioRepository _usuarioRepository;

        private const int UsuarioId = 1;
        private const string Modulo = "consultorias-assessorias";

        public ValidacaoPermissaoUseCaseTests()
        {
            _usuarioRepository = Substitute.For<IUsuarioRepository>();
            _validacaoPermissaoUseCase = new ValidacaoPermissaoUseCase(_usuarioRepository);
        }

        [Theory]
        [InlineData(Modulo)]
        [InlineData("home")]
        public async Task DeveRetornarPermissao(string modulo)
        {
            // arrange
            var usuario = new Usuario
            {
                Id = UsuarioId,
                Modulos = new List<UsuarioModulo>
                {
                     new UsuarioModulo { Modulo = new Modulo { Nome = Modulo } }
                }
            };

            _usuarioRepository.ObterUsuarioPorId(UsuarioId).Returns(usuario);

            // act
            var resultado = await _validacaoPermissaoUseCase.ValidarPermissao(UsuarioId, modulo);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public async Task NaoDeveRetornarPermissao()
        {
            // arrange
            var usuario = new Usuario
            {
                Id = UsuarioId,
                Modulos = new List<UsuarioModulo>
                {
                     new UsuarioModulo { Modulo = new Modulo { Nome = "outro-modulo" } }
                }
            };

            _usuarioRepository.ObterUsuarioPorId(UsuarioId).Returns(usuario);

            // act
            var resultado = await _validacaoPermissaoUseCase.ValidarPermissao(UsuarioId, Modulo);

            // Assert
            Assert.False(resultado);
        }
    }
}
