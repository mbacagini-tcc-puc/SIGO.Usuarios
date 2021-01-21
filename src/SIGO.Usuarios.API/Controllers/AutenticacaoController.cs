using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.API.Models;
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
        public async Task<IActionResult> Autenticar([FromBody] AutenticacaoInput input)
        {
            var resultado = await _autenticacaoUseCase.IniciarAutenticacao(input.Email, input.Senha);

            if(resultado == null)
            {
                return Unauthorized();
            }

            return Ok(resultado);
        }
    }
}