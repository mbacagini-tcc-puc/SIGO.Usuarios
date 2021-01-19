using SIGO.Usuarios.Entities;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorCredenciais(string email, string senha);

        Task<Usuario> ObterUsuarioPorRefreshToken(string refreshToken);

        Task<Usuario> ObterUsuarioPorId(int id);

        Task InserirUsuario(Usuario usuario);

        Task AtualizarUsuario(Usuario usuario);
    }
}
