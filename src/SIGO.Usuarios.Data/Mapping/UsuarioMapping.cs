using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Usuarios.Entities;
using System;

namespace SIGO.Usuarios.Data.Mapping
{
    public class UsuarioMapping : BaseEntityMapping<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.Property(prop => prop.Email).HasColumnName("email").HasMaxLength(512);
            builder.Property(prop => prop.Senha).HasColumnName("senha").HasMaxLength(512);
            builder.Property(prop => prop.Nome).HasColumnName("nome").HasMaxLength(100);
            builder.Property(prop => prop.Celular).HasColumnName("celular").HasMaxLength(40);
            builder.Property(prop => prop.CodigoVerificacao).HasColumnName("codigo_verificacao").HasMaxLength(6);
            builder.Property(prop => prop.ExpiracaoCodigoVerificacao).HasColumnName("expiracao_codigo_verificacao");
            builder.HasMany(prop => prop.Modulos).WithOne().HasForeignKey(prop => prop.UsuarioId);
            base.Configure(builder);

            builder.HasData(new Usuario[]
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    Email = "6CA8AD90817B9A591E1EEDC5C183F4C9E4E2B32E1DD6EFDD688D2A47A0A83A79",
                    Senha = "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow
                }
            });
        }
    }
}
