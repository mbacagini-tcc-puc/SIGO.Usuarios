using Microsoft.IdentityModel.Tokens;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.TransferObjects;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace SIGO.Usuarios.API.Auth
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly TokenConfigurations _tokenConfigurations;

        public AuthTokenService(TokenConfigurations tokenConfigurations)
        {
            _tokenConfigurations = tokenConfigurations;
        }

        public string GerarToken(ClaimsInfo info)
        {
            var identity = new ClaimsIdentity(
                     new[] {
                        new Claim("email", info.Email),
                        new Claim("cellphone", info.Celular),
                        new Claim("name", info.Nome),
                        new Claim("userid", info.UsuarioId.ToString()),
                        new Claim("role", info.Perfil),
                     });

            var dataCriacao = DateTime.UtcNow;
            var dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _tokenConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

           return handler.WriteToken(securityToken);
        }
    }
}
