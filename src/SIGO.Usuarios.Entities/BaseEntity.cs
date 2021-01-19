using System;

namespace SIGO.Usuarios.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
