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
        public DateTime? ExpiracaoCodigoVerificacao { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? ExpiracaoRefreshToken { get; set; }
        public virtual ICollection<Modulo> Modulos { get; set; }
    }
}
