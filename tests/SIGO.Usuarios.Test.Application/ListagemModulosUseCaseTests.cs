using NSubstitute;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.UseCases.Modulos.Listagem;
using SIGO.Usuarios.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Application
{
    public class ListagemModulosUseCaseTests
    {
        private readonly ListagemModulosUseCase _listagemModulosUseCase;
        private readonly IModuloRepository _moduloRepository;

        public ListagemModulosUseCaseTests()
        {
            _moduloRepository = Substitute.For<IModuloRepository>();
            _listagemModulosUseCase = new ListagemModulosUseCase(_moduloRepository);
        }

        [Fact]
        public async Task DeveListarModulos()
        {
            // arrange

            var idModulo = 1;
            var nomeModulo = "Usuários";

            _moduloRepository.Listar().Returns(
                new List<Modulo> { new Modulo { Id = idModulo, NomeExibicao = nomeModulo } }
             );

            // act
            var resultado = await _listagemModulosUseCase.ListarModulos();

            // assert
            Assert.Equal(idModulo, resultado.FirstOrDefault().Id);
            Assert.Equal(nomeModulo, resultado.FirstOrDefault().NomeExibicao);
        }
    }
}
