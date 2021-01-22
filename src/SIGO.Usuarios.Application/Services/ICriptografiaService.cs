namespace SIGO.Usuarios.Application.Services
{
    public interface ICriptografiaService
    {
        string Criptografar(string texto);
        string Descriptografar(string textoCriptografado);
    }
}
