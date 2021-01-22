using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SIGO.Usuarios.API.Controllers;
using SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class ConfirmacaoMultifatorControllerTests
    {
        private readonly ConfirmacaoMultifatorController _confirmacaoMultifatorController;
        private readonly IConfirmacaoMultifatorUseCase _confirmacaoMultifatorUseCase;

        private const int UsuarioId = 1;
        private const string CodigoVerificacao = "795645";

        public ConfirmacaoMultifatorControllerTests()
        {
            _confirmacaoMultifatorUseCase = Substitute.For<IConfirmacaoMultifatorUseCase>();
            _confirmacaoMultifatorController = new ConfirmacaoMultifatorController(_confirmacaoMultifatorUseCase);
        }

        [Fact]
        public async Task DeveRetornarNaoAutorizado()
        {
            // arrange
            _confirmacaoMultifatorUseCase.FinalizarAutenticacao(UsuarioId, CodigoVerificacao).Returns((ConfirmacaoAutenticacaoOutput)null);

            // act
            var resultado = await _confirmacaoMultifatorController.ConfirmarAutenticacao(new API.Models.ConfirmacaoAutenticacaoInput
            {
                 CodigoVerificacao = CodigoVerificacao,
                 UsuarioId = UsuarioId
            });

            // assert
            Assert.IsType<UnauthorizedResult>(resultado);
        }

        [Fact]
        public async Task DeveConfirmarAutenticacao()
        {
            // arrange
            var output = new ConfirmacaoAutenticacaoOutput();

            _confirmacaoMultifatorUseCase.FinalizarAutenticacao(UsuarioId, CodigoVerificacao).Returns(output);

            // act
            var resultado = await _confirmacaoMultifatorController.ConfirmarAutenticacao(new API.Models.ConfirmacaoAutenticacaoInput
            {
                CodigoVerificacao = CodigoVerificacao,
                UsuarioId = UsuarioId
            });

            // assert
            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(output, ((OkObjectResult)resultado).Value);
        }
    }
}
