using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleStoreMvc.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnName("varchar(200)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnName("varchar(50)");

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnName("varchar(8)");

            builder.Property(e => e.Complemento)
                .IsRequired()
                .HasColumnName("varchar(250)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnName("varchar(100)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnName("varchar(100)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnName("varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
