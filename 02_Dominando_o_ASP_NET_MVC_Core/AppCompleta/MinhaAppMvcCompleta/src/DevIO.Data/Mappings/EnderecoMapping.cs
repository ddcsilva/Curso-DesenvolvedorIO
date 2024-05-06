using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

/// <summary>
/// Classe que representa o mapeamento da entidade Endereco.
/// </summary>
public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    /// <summary>
    /// Método que configura o mapeamento da entidade Endereco.
    /// </summary>
    /// <param name="builder">Objeto que contém as configurações da entidade Endereco.</param>
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        // Configuração da Tabela
        builder.ToTable("TB_ENDERECOS", t => t.HasComment("Tabela de Endereços"));

        // Configuração da Chave Primária
        builder.HasKey(e => e.Id)
            .HasName("PK_ENDERECOS");

        // Configuração das Relações
        builder.HasOne(e => e.Fornecedor) // Endereço tem um Fornecedor
            .WithOne(f => f.Endereco) // Fornecedor tem um Endereço
            .HasForeignKey<Endereco>(e => e.FornecedorId)
            .HasConstraintName("FK_ENDERECO_FORNECEDOR");

        // Configuração das Propriedades
        builder.Property(e => e.Id)
            .HasColumnName("END_ID")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador Único do Endereço");

        builder.Property(e => e.Logradouro)
            .HasColumnName("END_LOGRADOURO")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Logradouro do Endereço");

        builder.Property(e => e.Numero)
            .HasColumnName("END_NUMERO")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Número do Endereço");

        builder.Property(e => e.Complemento)
            .HasColumnName("END_COMPLEMENTO")
            .HasColumnOrder(4)
            .HasColumnType("varchar(100)")
            .HasComment("Complemento do Endereço");

        builder.Property(e => e.Cep)
            .HasColumnName("END_CEP")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("varchar(8)")
            .HasComment("CEP do Endereço");

        builder.Property(e => e.Bairro)
            .HasColumnName("END_BAIRRO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Bairro do Endereço");

        builder.Property(e => e.Cidade)
            .HasColumnName("END_CIDADE")
            .HasColumnOrder(7)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Cidade do Endereço");

        builder.Property(e => e.Estado)
            .HasColumnName("END_ESTADO")
            .HasColumnOrder(8)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasComment("Estado do Endereço");
    }
}