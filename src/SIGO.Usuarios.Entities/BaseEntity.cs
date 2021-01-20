using System;

namespace SIGO.Usuarios.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTimeOffset DataInclusao { get; set; }
        public DateTimeOffset? DataAlteracao { get; set; }
    }
}
