using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.TransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.API.Auth
{
    public static class AuthMiddleware
    {
        public static Func<TokenValidatedContext, Task> Execute()
        {
            return ctx =>
            {
                var usuarioAutenticadoService = ctx.HttpContext.RequestServices.GetRequiredService<IUsuarioAutenticadoService>();
                var claims = ctx.Principal?.Claims;

                if (claims?.Any() == true)
                {
                    var id  = Convert.ToInt32(claims.FirstOrDefault(c => c.Type.Contains("userid")).Value);

                    usuarioAutenticadoService.Usuario = new UsuarioAutenticado
                    {
                       Id = id
                    };
                }

                return Task.CompletedTask;
            };
        }

    }
}
