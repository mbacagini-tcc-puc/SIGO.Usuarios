using SIGO.Usuarios.API.Auth;
using SIGO.Usuarios.Application.TransferObjects;
using Xunit;

namespace SIGO.Usuarios.Test.Api
{
    public class AuthTokenServiceTests
    {
        private readonly AuthTokenService _authTokenService;
        private readonly TokenConfigurations _tokenConfigurations;

        public AuthTokenServiceTests()
        {
            _tokenConfigurations = new TokenConfigurations
            {
                Audience = "SIGO",
                Issuer = "Indtextbr",
                Seconds = 3600,
                SecurityKey = new string('a', 44)
            };

            _authTokenService = new AuthTokenService(_tokenConfigurations);
        }

        [Fact]
        public void DeveGerarToken()
        {
            // act
            var token = _authTokenService.GerarToken(new ClaimsInfo
            {
                UsuarioId = 1,
                Email = "teste@teste.com.br",
                Celular = "+115599999999",
                Nome = "José",
                Perfil = "Usuário Interno"
            });

            // assert
            Assert.NotNull(token);
        }
    }
}
