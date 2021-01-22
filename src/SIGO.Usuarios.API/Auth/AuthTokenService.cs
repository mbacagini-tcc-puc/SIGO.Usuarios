using Microsoft.IdentityModel.Tokens;
using SIGO.Usuarios.Application.Services;
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

        public string GerarToken(int usuarioId, string email, string nome)
        {
            var identity = new ClaimsIdentity(
                     new GenericIdentity(nome),
                     new[] {
                        new Claim(JwtRegisteredClaimNames.Email, email),
                        new Claim("userid", usuarioId.ToString())
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
