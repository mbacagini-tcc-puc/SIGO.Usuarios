using SIGO.Usuarios.Application.Repositories;
using SIGO.Usuarios.Application.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Application.UseCases.ConfirmacaoMultifator
{
    public class ConfirmacaoMultifatorUseCase : IConfirmacaoMultifatorUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthTokenService _authTokenService;

        public ConfirmacaoMultifatorUseCase(IUsuarioRepository usuarioRepository, IAuthTokenService authTokenService)
        {
            _usuarioRepository = usuarioRepository;
            _authTokenService = authTokenService;
        }

        public async Task<ConfirmacaoAutenticacaoOutput> FinalizarAutenticacao(int usuarioId, string codigoVerificacao)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorId(usuarioId);

            if (usuario.CodigoVerificacao != codigoVerificacao || DateTime.UtcNow > usuario.ExpiracaoCodigoVerificacao)
            {
                return null;
            }

            usuario.CodigoVerificacao = null;
            usuario.ExpiracaoCodigoVerificacao = null;

            await _usuarioRepository.AtualizarUsuario(usuario);

            var token = _authTokenService.GerarToken(usuario.Id, usuario.Email);
            var modulosPermitidos = usuario.Modulos.Select(mod => mod.Modulo.Nome).ToArray();

            return new ConfirmacaoAutenticacaoOutput
            {
                AccessToken = token,
                Modulos = modulosPermitidos
            };
        }
    }
}
