using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator
{
    public interface IConfirmacaoMultifatorUseCase
    {
        Task<ConfirmacaoAutenticacaoOutput> FinalizarAutenticacao(int usuarioId, string codigoVerificacao);
    }
}
