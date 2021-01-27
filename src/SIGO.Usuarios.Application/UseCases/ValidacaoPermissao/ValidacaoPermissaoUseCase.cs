using SIGO.Usuarios.Application.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.ValidacaoPermissao
{
    public class ValidacaoPermissaoUseCase : IValidacaoPermissaoUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ValidacaoPermissaoUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> ValidarPermissao(int usuarioId, string modulo)
        {
            if(modulo == "home")
            {
                return true;
            }

            var usuario = await _usuarioRepository.ObterUsuarioPorId(usuarioId);

            return usuario.Modulos.Any(moduloPermitido => moduloPermitido.Modulo.Nome == modulo);
        }
    }
}
