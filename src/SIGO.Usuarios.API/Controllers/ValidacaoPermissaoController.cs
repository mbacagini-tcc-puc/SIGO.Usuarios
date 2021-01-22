using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.Application.Services;

namespace SIGO.Usuarios.API.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    public class ValidacaoPermissaoController : ControllerBase
    {
        private readonly IUsuarioAutenticadoService _usuarioAutenticadoService;

        public ValidacaoPermissaoController(IUsuarioAutenticadoService usuarioAutenticadoService)
        {
            _usuarioAutenticadoService = usuarioAutenticadoService;
        }

        [Route("auth/permissoes")]
        public IActionResult ValidarPermissao([FromQuery] string modulo)
        {
            var usuario = _usuarioAutenticadoService.Usuario;

            return Ok();
        }
    }
}