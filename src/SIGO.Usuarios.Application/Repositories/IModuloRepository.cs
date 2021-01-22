using SIGO.Usuarios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.Repositories
{
    public interface IModuloRepository
    {
        Task<IEnumerable<Modulo>> Listar();
    }
}
