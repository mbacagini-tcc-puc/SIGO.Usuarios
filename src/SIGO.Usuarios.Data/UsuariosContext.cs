using Microsoft.EntityFrameworkCore;
using SIGO.Usuarios.Data.Mapping;
using SIGO.Usuarios.Entities;

namespace SIGO.Usuarios.Data
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
            modelBuilder.Entity<Modulo>(new ModuloMapping().Configure);
            modelBuilder.Entity<UsuarioModulo>(new UsuarioModuloMapping().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
