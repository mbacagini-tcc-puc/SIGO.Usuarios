using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Usuarios.Entities;
using System;

namespace SIGO.Usuarios.Data.Mapping
{
    public class ModuloMapping : BaseEntityMapping<Modulo>
    {
        public override void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("modulos");
            builder.Property(prop => prop.Nome).HasColumnName("nome").HasMaxLength(50);
            builder.Property(prop => prop.NomeExibicao).HasColumnName("nome_exibicao").HasMaxLength(50);
            base.Configure(builder);

            builder.HasData(new Modulo[]
            {
                new Modulo { Id = 1, Nome = "usuarios", NomeExibicao = "Gerenciamento de Usuários", DataInclusao = DateTime.UtcNow },
                new Modulo { Id = 2, Nome = "normas-tecnicas", NomeExibicao = "Normas Técnicas", DataInclusao = DateTime.UtcNow },
                new Modulo { Id = 3, Nome = "assessorias-consultorias", NomeExibicao = "Assessorias e Consultorias", DataInclusao = DateTime.UtcNow }
            });
        }
    }
}
