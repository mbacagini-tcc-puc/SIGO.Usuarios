using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.Modulos.Listagem
{
    public interface IListagemModulosUseCase
    {
        Task<IEnumerable<ListagemModuloOutput>> ListarModulos();
    }
}
