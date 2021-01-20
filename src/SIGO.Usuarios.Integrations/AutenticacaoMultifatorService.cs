using SIGO.Usuarios.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SIGO.Usuarios.Integrations
{
    public class AutenticacaoMultifatorService : IAutenticacaoMultifatorService
    {
        public async Task EnviarConfirmacaoMultifator(string numeroCelular, string codigoVerificacao)
        {
            await Task.Delay(10);
        }
    }
}
