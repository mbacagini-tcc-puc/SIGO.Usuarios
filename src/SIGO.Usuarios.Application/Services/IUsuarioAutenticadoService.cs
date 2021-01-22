using SIGO.Usuarios.Application.TransferObjects;

namespace SIGO.Usuarios.Application.Services
{
    public interface IUsuarioAutenticadoService
    {
        UsuarioAutenticado Usuario { get; set; }
    }
}
