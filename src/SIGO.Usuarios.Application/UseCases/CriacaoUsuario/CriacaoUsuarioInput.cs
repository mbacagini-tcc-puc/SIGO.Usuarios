using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.Usuarios.Application.UseCases.CriacaoUsuario
{
    public class CriacaoUsuarioInput
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public int[] Modulos { get; set; }
    }
}
