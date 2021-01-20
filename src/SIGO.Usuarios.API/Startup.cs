using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.UseCases.Autenticacao;
using SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator;
using SIGO.Usuarios.Application.UseCases.ValidacaoPermissao;
using SIGO.Usuarios.Data;
using SIGO.Usuarios.Data.Repositories;
using SIGO.Usuarios.Integrations;
using SIGO.Usuarios.Security;

namespace SIGO.Usuarios.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UsuariosContext>(options => options.UseNpgsql(
                                                             Configuration["ConnectionStrings:DefaultConnection"],
                                                             postgresOptions => postgresOptions.CommandTimeout(180)
                                                              ));

            services.AddScoped<IAutenticacaoUseCase, AutenticacaoUseCase>();
            services.AddScoped<IConfirmacaoMultifatorUseCase, ConfirmacaoMultifatorUseCase>();
            services.AddScoped<IValidacaoPermissaoUseCase, ValidacaoPermissaoUseCase>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IAuthTokenService, AuthTokenService>();
            services.AddScoped<IAutenticacaoMultifatorService, AutenticacaoMultifatorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
        }


    }
}
