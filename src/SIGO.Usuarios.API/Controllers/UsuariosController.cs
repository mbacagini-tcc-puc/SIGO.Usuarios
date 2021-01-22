using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.Application.UseCases.CriacaoUsuario;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICriacaoUsuarioUseCase _criacaoUsuarioUseCase;

        public UsuariosController(ICriacaoUsuarioUseCase criacaoUsuarioUseCase)
        {
            _criacaoUsuarioUseCase = criacaoUsuarioUseCase;
        }

        public async Task<IActionResult> CriarUsuario([FromBody] CriacaoUsuarioInput usuarioInput)
        {
            var idNovoUsuario = await _criacaoUsuarioUseCase.CriarUsuario(usuarioInput);

            return Ok(idNovoUsuario);
        }
    }
}