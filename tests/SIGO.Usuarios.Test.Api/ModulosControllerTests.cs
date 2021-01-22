using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SIGO.Usuarios.API.Controllers;
using SIGO.Usuarios.Application.UseCases.Modulos.Listagem;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class ModulosControllerTests
    {
        private readonly ModulosController _modulosController;
        private readonly IListagemModulosUseCase _listagemModulosUseCase;

        public ModulosControllerTests()
        {
            _listagemModulosUseCase = Substitute.For<IListagemModulosUseCase>();
            _modulosController = new ModulosController(_listagemModulosUseCase);
        }

        [Fact]
        public async Task DeveListarModulos()
        {
            // arrange
            var modulos = new List<ListagemModuloOutput>();

            _listagemModulosUseCase.ListarModulos().Returns(modulos);

            // act
            var resultado = await _modulosController.ListarModulos();

            // assert
            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(modulos, ((OkObjectResult)resultado).Value);
        }
    }
}
