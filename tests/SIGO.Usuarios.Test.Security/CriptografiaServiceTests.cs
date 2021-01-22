using Microsoft.Extensions.Configuration;
using NSubstitute;
using SIGO.Usuarios.Security;
using Xunit;

namespace SIGO.Usuarios.Test.Security
{
    public class CriptografiaServiceTests
    {
        private readonly CriptografiaService _criptografiaService;
        private readonly IConfiguration _configuration;

        public CriptografiaServiceTests()
        {
            _configuration = Substitute.For<IConfiguration>();
            _configuration["SIGOCriptografia:key"].Returns(new string('a', 24));
            _configuration["SIGOCriptografia:iv"].Returns(new string('b', 16));
            _criptografiaService = new CriptografiaService(_configuration);
        }

        [Theory]
        [InlineData("+5511999999999")]
        [InlineData("teste@teste.com.br")]
        [InlineData("Uma frase qualquer com acentuação.")]
        public void DeveCriptografar(string texto)
        {
            // act
            var textoCriptografado = _criptografiaService.Criptografar(texto);
            var textoDescriptografado = _criptografiaService.Descriptografar(textoCriptografado);

            // assert
            Assert.Equal(texto, textoDescriptografado);
        }
    }
}
