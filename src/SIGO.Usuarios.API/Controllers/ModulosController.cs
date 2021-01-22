using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Usuarios.Application.UseCases.Modulos.Listagem;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Controllers
{
    [Authorize("Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class ModulosController : ControllerBase
    {
        private readonly IListagemModulosUseCase _listagemModulosUseCase;

        public ModulosController(IListagemModulosUseCase listagemModulosUseCase)
        {
            _listagemModulosUseCase = listagemModulosUseCase;
        }

        public async Task<IActionResult> ListarModulos()
        {
            var modulos = await _listagemModulosUseCase.ListarModulos();

            return Ok(modulos);
        }
    }
}