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
                    Nome = "Murilo",
                    Email = "D837ECDE06F1C5BD58C8439D226B0B2CF5FD68AAD16B014DF691065FF1D3C90D",
                    Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow
                },

                new Usuario
                {
                    Id = 2,
                    Nome = "José Carlos Santos",
                    Email = "C7BAFB527E21B2D84C246EA6B07C4FBE03C429CE62B43C57F8DE48AF48A9F52B",
                    Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow,
                    UsuarioExterno = true,
                },

                new Usuario
                {
                    Id = 3,
                    Nome = "Ana Maria Oliveira",
                    Email = "C7BAFB527E21B2D84C246EA6B07C4FBE6155E04E10E1A0AA0ECD6596F7512C95",
                    Senha = "96c90eb59dc05559ba78f4f6e76def228f18d0bad15d32a7886996ceb5d63d1a8a9c905d8667451de20cbaac46a3379d4a5469a1e285d692005b9f7b55aefb23",
                    Celular = "AC6D5A87D5F3656E4D46A5224CD2D52A",
                    DataInclusao = DateTime.UtcNow,
                    UsuarioExterno = true
                }
            });
        }
    }
}
