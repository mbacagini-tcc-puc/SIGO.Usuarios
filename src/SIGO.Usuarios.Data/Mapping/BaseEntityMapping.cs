using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Usuarios.Entities;


namespace SIGO.Usuarios.Data.Mapping
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .Property(prop => prop.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder
                .Property(prop => prop.DataInclusao)
                .HasColumnName("data_inclusao");

            builder
                .Property(prop => prop.DataAlteracao)
                .HasColumnName("data_alteracao");
        }
    }
}
