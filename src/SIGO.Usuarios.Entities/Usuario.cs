using System;
using System.Collections.Generic;

namespace SIGO.Usuarios.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public string CodigoVerificacao { get; set; }
        public bool UsuarioExterno { get; set; }
        public DateTimeOffset? ExpiracaoCodigoVerificacao { get; set; }
        public virtual ICollection<UsuarioModulo> Modulos { get; set; }
    }
}
