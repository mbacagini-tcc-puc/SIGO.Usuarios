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
            builder.Property(prop => prop.Celular).HasColumnName("celular").HasMaxLength(15);
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
                    Email = "d830635c6cc19bb67f732cf95653100d55c7f17b4523b2bab3a62408b81c00f3f7f71e8a910693ed8767b7f84aa95c463b4eee614957043200a9931e02ecfc80",
                    Senha = "4c7ad029115071a8cdfaa17aae1a997b9e5f891033b771d38b79b07fd44a887909144ce6f015ed7b62efefdf6564079d7b4407db226065147dd1e48cc0a868df",
                    Celular = "1199999999",
                    DataInclusao = DateTime.UtcNow
                }
            });
        }
    }
}
