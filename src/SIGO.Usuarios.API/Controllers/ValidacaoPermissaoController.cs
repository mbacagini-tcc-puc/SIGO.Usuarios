using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.UseCases.ValidacaoPermissao;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    public class ValidacaoPermissaoController : ControllerBase
    {
        private readonly IValidacaoPermissaoUseCase _validacaoPermissaoUseCase;
        private readonly IUsuarioAutenticadoService _usuarioAutenticadoService;

        public ValidacaoPermissaoController(IUsuarioAutenticadoService usuarioAutenticadoService, IValidacaoPermissaoUseCase validacaoPermissaoUseCase)
        {
            _usuarioAutenticadoService = usuarioAutenticadoService;
            _validacaoPermissaoUseCase = validacaoPermissaoUseCase;
        }

        [Route("auth/permissoes")]
        public async Task< IActionResult> ValidarPermissao([FromQuery] string modulo)
        {
            var permitido = await _validacaoPermissaoUseCase.ValidarPermissao(_usuarioAutenticadoService.Usuario.Id, modulo);

            if(!permitido)
            {
                return Forbid();
            }

            return Ok();
        }
    }
}