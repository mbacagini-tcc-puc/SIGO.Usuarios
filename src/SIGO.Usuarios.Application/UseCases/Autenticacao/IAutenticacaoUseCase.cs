using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.Autenticacao
{
    public interface IAutenticacaoUseCase
    {
        Task<AutenticacaoOutput> IniciarAutenticacao(string email, string senha);
    }
}
