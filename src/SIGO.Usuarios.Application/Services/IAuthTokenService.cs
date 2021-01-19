namespace SIGO.Usuarios.Application.Services
{
    public interface IAuthTokenService
    {
        string GerarToken(int usuarioId, string email);
    }
}
