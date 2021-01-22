using SIGO.Usuarios.Application.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.Modulos.Listagem
{
    public class ListagemModulosUseCase : IListagemModulosUseCase
    {
        private readonly IModuloRepository _moduloRepository;

        public ListagemModulosUseCase(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }

        public async Task<IEnumerable<ListagemModuloOutput>> ListarModulos()
        {
            var modulos = await _moduloRepository.Listar();
            var output = modulos.Select(modulo => new ListagemModuloOutput
            {
                Id = modulo.Id,
                NomeExibicao = modulo.NomeExibicao
            });

            return output;
        }
    }
}
