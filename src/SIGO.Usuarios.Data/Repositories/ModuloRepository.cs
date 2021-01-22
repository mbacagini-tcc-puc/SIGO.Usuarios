using Microsoft.EntityFrameworkCore;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Data.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly UsuariosContext _context;

        public ModuloRepository(UsuariosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modulo>> Listar()
        {
            return await _context.Modulos.ToListAsync();
        }
    }
}
