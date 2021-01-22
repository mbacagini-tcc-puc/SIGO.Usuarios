using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SIGO.Usuarios.API.Controllers;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.TransferObjects;
using SIGO.Usuarios.Application.UseCases.ValidacaoPermissao;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class ValidacaoPermissaoControllerTests
    {
        private readonly ValidacaoPermissaoController _validacaoPermissaoController;
        private readonly IValidacaoPermissaoUseCase _validacaoPermissaoUseCase;
        private readonly IUsuarioAutenticadoService _usuarioAutenticadoService;

        private const int UsuarioId = 1;
        private const string Modulo = "usuarios";

        public ValidacaoPermissaoControllerTests()
        {
            _validacaoPermissaoUseCase = Substitute.For<IValidacaoPermissaoUseCase>();
            _usuarioAutenticadoService = Substitute.For<IUsuarioAutenticadoService>();
            _validacaoPermissaoController = new ValidacaoPermissaoController(_usuarioAutenticadoService, _validacaoPermissaoUseCase);
            _usuarioAutenticadoService.Usuario.Returns(new UsuarioAutenticado
            {
                 Id = UsuarioId
            });
        }

        [Fact]
        public async Task DeveRetornarForbid()
        {
            // arrange
            _validacaoPermissaoUseCase.ValidarPermissao(UsuarioId, Modulo).Returns(false);

            // act
            var resultado = await _validacaoPermissaoController.ValidarPermissao(Modulo);

            // assert
            Assert.IsType<ForbidResult>(resultado);
        }

        [Fact]
        public async Task DeveRetornarOk()
        {
            // arrange
            _validacaoPermissaoUseCase.ValidarPermissao(UsuarioId, Modulo).Returns(true);

            // act
            var resultado = await _validacaoPermissaoController.ValidarPermissao(Modulo);

            // assert
            Assert.IsType<OkResult>(resultado);
        }
    }
}
