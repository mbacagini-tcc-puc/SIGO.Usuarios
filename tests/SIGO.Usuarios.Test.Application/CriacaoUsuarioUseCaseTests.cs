using NSubstitute;
using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using SIGO.Usuarios.Application.UseCases.CriacaoUsuario;
using SIGO.Usuarios.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SIGO.Usuarios.Test.Application
{
    public class CriacaoUsuarioUseCaseTests
    {
        private readonly CriacaoUsuarioUseCase _criacaoUsuarioUseCase;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHashService _hashService;
        private readonly ICriptografiaService _criptografiaService;

        public CriacaoUsuarioUseCaseTests()
        {
            _usuarioRepository = Substitute.For<IUsuarioRepository>();
            _hashService = Substitute.For<IHashService>();
            _criptografiaService = Substitute.For<ICriptografiaService>();
            _criacaoUsuarioUseCase = new CriacaoUsuarioUseCase(_usuarioRepository, _hashService, _criptografiaService);
        }

        [Fact]
        public async Task DeveCriarUsuario()
        {
            // arrange

            var nome = "José";
            var email = "jose@teste.com.br";
            var emailCriptografado = "AA1274D78DA74D7D87FDA4DF7D874";
            var senha = "123456";
            var senhaHash = "AD4D74F778D7FDA74D7F7DA787DF87A87F";
            var celular = "+551199999999";
            var celularCriptografado = "AD54D77D787DFA7DF7D8";
            var modulos = new int[] { 1, 2, 3 };
            var input = new CriacaoUsuarioInput
            {
                 Nome = nome,
                 Email = email,
                 Senha = senha,
                 Celular = celular,
                 Modulos = modulos
            };

            _hashService.Hash(senha).Returns(senhaHash);
            _criptografiaService.Criptografar(email).Returns(emailCriptografado);
            _criptografiaService.Criptografar(celular).Returns(celularCriptografado);

            Usuario usuarioCriado = null;

            await _usuarioRepository.InserirUsuario(Arg.Do<Usuario>(recebido => usuarioCriado = recebido));

            // act
            await _criacaoUsuarioUseCase.CriarUsuario(input);

            // assert
            Assert.Equal(nome, usuarioCriado.Nome);
            Assert.Equal(emailCriptografado, usuarioCriado.Email);
            Assert.Equal(senhaHash, usuarioCriado.Senha);
            Assert.Equal(celularCriptografado, usuarioCriado.Celular);
            Assert.Equal(3, usuarioCriado.Modulos.Count);
            Assert.True(usuarioCriado.Modulos.All(modulo => modulo.Usuario == usuarioCriado));
            Assert.True(usuarioCriado.Modulos.All(modulo => modulos.Contains(modulo.ModuloId)));
        }
    }
}
