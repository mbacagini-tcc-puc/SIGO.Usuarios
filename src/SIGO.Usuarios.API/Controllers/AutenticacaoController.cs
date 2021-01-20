using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.Application.UseCases.Autenticacao;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Controllers
{
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoUseCase _autenticacaoUseCase;

        public AutenticacaoController(IAutenticacaoUseCase autenticacaoUseCase)
        {
            _autenticacaoUseCase = autenticacaoUseCase;
        }

        [Route("auth")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromForm] string email, [FromForm] string senha)
        {
            var resultado = await _autenticacaoUseCase.IniciarAutenticacao(email, senha);

            if(resultado == null)
            {
                return Unauthorized();
            }

            return Ok(resultado);
        }
    }
}