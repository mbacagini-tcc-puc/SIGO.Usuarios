using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.CriacaoUsuario
{
    public interface ICriacaoUsuarioUseCase
    {
        Task<int> CriarUsuario(CriacaoUsuarioInput usuarioInput);
    }
}
