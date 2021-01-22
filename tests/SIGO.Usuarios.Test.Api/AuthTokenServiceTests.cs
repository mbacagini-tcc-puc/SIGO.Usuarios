using SIGO.Usuarios.API.Auth;
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
           var token =  _authTokenService.GerarToken(1, "teste@teste.com.br", "José");

            // assert
            Assert.NotNull(token);
        }
    }
}
