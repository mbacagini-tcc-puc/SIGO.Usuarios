using SIGO.Usuarios.Application.TransferObjects;

namespace SIGO.Usuarios.Application.Services
{
    public interface IAuthTokenService
    {
        string GerarToken(ClaimsInfo info);
    }
}
