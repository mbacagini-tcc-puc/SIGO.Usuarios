using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SIGO.Usuarios.API.Controllers;
using SIGO.Usuarios.API.Models;
using SIGO.Usuarios.Application.UseCases.Autenticacao;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class AutenticacaoControllersTests
    {
        private readonly AutenticacaoController _autenticacaoController;
        private readonly IAutenticacaoUseCase _autenticacaoUseCase;

        private const string Email = "email@teste.com";
        private const string Senha = "123456";

        public AutenticacaoControllersTests()
        {
            _autenticacaoUseCase = Substitute.For<IAutenticacaoUseCase>();
            _autenticacaoController = new AutenticacaoController(_autenticacaoUseCase);
        }

        [Fact]
        public async Task DeveRetornarNaoAutorizado()
        {
            // arrange
            _autenticacaoUseCase.IniciarAutenticacao(Email, Senha).Returns((AutenticacaoOutput) null);

            // act
            var resultado = await _autenticacaoController.Autenticar(new AutenticacaoInput { Email = Email, Senha = Senha });

            // assert
            Assert.IsType<UnauthorizedResult>(resultado);
        }

        [Fact]
        public async Task DeveConcluirPrimeiraParteAutenticacao()
        {
            // arrange
            var output = new AutenticacaoOutput();

            _autenticacaoUseCase.IniciarAutenticacao(Email, Senha).Returns(output);

            // act
            var resultado = await _autenticacaoController.Autenticar(new AutenticacaoInput { Email = Email, Senha = Senha });

            // assert
            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(output, ((OkObjectResult)resultado).Value);
        }
    }
}
