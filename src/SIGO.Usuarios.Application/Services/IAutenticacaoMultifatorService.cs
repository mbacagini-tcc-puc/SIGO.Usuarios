using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.Services
{
    public interface IAutenticacaoMultifatorService
    {
        Task EnviarConfirmacaoMultifator(string numeroCelular, string codigoVerificacao);
    }
}
