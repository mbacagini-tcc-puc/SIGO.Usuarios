using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Usuarios.Entities;
using System;

namespace SIGO.Usuarios.Data.Mapping
{
    public class UsuarioModuloMapping : BaseEntityMapping<UsuarioModulo>
    {
        public override void Configure(EntityTypeBuilder<UsuarioModulo> builder)
        {
            builder.ToTable("usuarios_modulos");
            builder.Property(prop => prop.UsuarioId).HasColumnName("id_usuario");
            builder.Property(prop => prop.ModuloId).HasColumnName("id_modulo");
            builder.HasOne(prop => prop.Modulo).WithMany().HasForeignKey(prop => prop.ModuloId);
            builder.HasOne(prop => prop.Usuario).WithMany(prop => prop.Modulos).HasForeignKey(prop => prop.UsuarioId);
            base.Configure(builder);

            builder.HasData(new UsuarioModulo[]
            {
                new UsuarioModulo { Id = 1, UsuarioId = 1, ModuloId = 1, DataInclusao = DateTime.UtcNow },
                new UsuarioModulo { Id = 2, UsuarioId = 1, ModuloId = 2, DataInclusao = DateTime.UtcNow },
                new UsuarioModulo { Id = 3, UsuarioId = 1, ModuloId = 3, DataInclusao = DateTime.UtcNow }
            });
        }
    }
}
