using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SIGO.Usuarios.API.Controllers;
using SIGO.Usuarios.Application.UseCases.CriacaoUsuario;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class UsuariosControllerTests
    {
        private readonly UsuariosController _usuariosController;
        private readonly ICriacaoUsuarioUseCase _criacaoUsuarioUseCase;

        public UsuariosControllerTests()
        {
            _criacaoUsuarioUseCase = Substitute.For<ICriacaoUsuarioUseCase>();
            _usuariosController = new UsuariosController(_criacaoUsuarioUseCase);
        }

        [Fact]
        public async Task DeveCriarUsuario()
        {
            // arrange

            var input = new CriacaoUsuarioInput();

            _criacaoUsuarioUseCase.CriarUsuario(input).Returns(2);

            // act
            var resultado = await _usuariosController.CriarUsuario(input);

            // assert
            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(2, ((OkObjectResult)resultado).Value);
        }
    }
}
