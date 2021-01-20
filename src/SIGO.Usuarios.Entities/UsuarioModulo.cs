namespace SIGO.Usuarios.Entities
{
    public class UsuarioModulo : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
