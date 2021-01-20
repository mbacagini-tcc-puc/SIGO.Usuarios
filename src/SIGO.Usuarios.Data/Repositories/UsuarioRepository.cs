using Microsoft.EntityFrameworkCore;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Entities;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext _context;

        public UsuarioRepository(UsuariosContext context)
        {
            _context = context;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task InserirUsuario(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObterUsuarioPorCredenciais(string email, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email == email && usuario.Senha == senha);
        }

        public async Task<Usuario> ObterUsuarioPorId(int id)
        {
            return await _context.Usuarios.Include(usuario => usuario.Modulos).ThenInclude(usuMod => usuMod.Modulo).FirstOrDefaultAsync(usuario => usuario.Id == id);
        }
    }
}
