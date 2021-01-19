using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.ValidacaoPermissao
{
    public interface IValidacaoPermissaoUseCase
    {
        Task<bool> ValidarPermissao(int usuarioId, string modulo);
    }
}
