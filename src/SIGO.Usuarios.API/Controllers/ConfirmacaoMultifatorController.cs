using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.API.Models;
using SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Controllers
{
    [ApiController]
    public class ConfirmacaoMultifatorController : ControllerBase
    {
        private readonly IConfirmacaoMultifatorUseCase _confirmacaoMultifatorUseCase;

        public ConfirmacaoMultifatorController(IConfirmacaoMultifatorUseCase confirmacaoMultifatorUseCase)
        {
            _confirmacaoMultifatorUseCase = confirmacaoMultifatorUseCase;
        }

        [Route("auth/verificacao")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConfirmarAutenticacao([FromBody] ConfirmacaoAutenticacaoInput input)
        {
            var resultado = await _confirmacaoMultifatorUseCase.FinalizarAutenticacao(input.UsuarioId, input.CodigoVerificacao);

            if(resultado == null)
            {
                return Unauthorized();
            }

            return Ok(resultado);
        }
    }
}