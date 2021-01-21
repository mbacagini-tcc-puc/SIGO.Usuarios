using SIGO.Usuarios.Security;
using Xunit;

namespace SIGO.Usuarios.Test.Security
{
    public class HashServiceTests
    {
        [Fact]
        public void DeveGerarHash()
        {
            // arrange
            var senha = "123456";
            var hashEsperado = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413";
           
            // act
            var hash = new HashService().Hash(senha);

            // Assert
            Assert.Equal(hashEsperado, hash);
        }
    }
}
