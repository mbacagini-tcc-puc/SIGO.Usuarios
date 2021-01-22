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
            builder.Property(prop => prop.UsuarioExterno).HasColumnName("usuario_externo");
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
                },

                new Usuario
                {
                    Id = 2,
                    Nome = "Consultor 1",
                    Email = "C7BAFB527E21B2D84C246EA6B07C4FBE03C429CE62B43C57F8DE48AF48A9F52B",
                    Senha = "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow,
                    UsuarioExterno = true,
                },

                new Usuario
                {
                    Id = 3,
                    Nome = "Consultor 2",
                    Email = "C7BAFB527E21B2D84C246EA6B07C4FBE6155E04E10E1A0AA0ECD6596F7512C95",
                    Senha = "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow,
                    UsuarioExterno = true
                }
            });
        }
    }
}
