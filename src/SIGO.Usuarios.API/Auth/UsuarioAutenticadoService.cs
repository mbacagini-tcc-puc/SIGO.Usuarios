using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.TransferObjects;

namespace SIGO.Usuarios.API.Auth
{
    public class UsuarioAutenticadoService : IUsuarioAutenticadoService
    {
        public UsuarioAutenticado Usuario { get; set; }
    }
}
