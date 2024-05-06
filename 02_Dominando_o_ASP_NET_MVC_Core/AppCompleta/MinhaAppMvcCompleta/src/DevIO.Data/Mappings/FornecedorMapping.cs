using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

/// <summary>
/// Classe que representa o mapeamento da entidade Fornecedor.
/// </summary>
public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
{
    // Método que configura o mapeamento da entidade Fornecedor
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        // Configuração da Tabela
        builder.ToTable("TB_FORNECEDORES", t => t.HasComment("Tabela de Fornecedores"));

        // Configuração da Chave Primária
        builder.HasKey(f => f.Id)
            .HasName("PK_FORNECEDORES");

        // Configuração das Relações
        builder.HasOne(f => f.Endereco) // Fornecedor tem um Endereço
            .WithOne(e => e.Fornecedor) // Endereço tem um Fornecedor
            .HasForeignKey<Endereco>(e => e.FornecedorId)
            .HasConstraintName("FK_ENDERECO_FORNECEDOR");

        builder.HasMany(f => f.Produtos) // Fornecedor tem muitos Produtos
            .WithOne(p => p.Fornecedor) // Produto tem um Fornecedor
            .HasForeignKey(p => p.FornecedorId)
            .HasConstraintName("FK_PRODUTO_FORNECEDOR");

        // Configuração dos Índices
        builder.HasIndex(f => f.Nome)
            .HasDatabaseName("IX_FORNECEDORES_NOME")
            .IsUnique()
            .HasFilter("[FOR_NOME] IS NOT NULL");

        builder.HasIndex(f => f.Documento)
            .HasDatabaseName("IX_FORNECEDORES_DOCUMENTO")
            .IsUnique()
            .HasFilter("[FOR_DOCUMENTO] IS NOT NULL");

        // Configuração das Propriedades
        builder.Property(f => f.Id)
            .HasColumnName("FOR_ID")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador Único do Fornecedor");

        builder.Property(f => f.Nome)
            .HasColumnName("FOR_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Nome do Fornecedor");

        builder.Property(f => f.Documento)
            .HasColumnName("FOR_DOCUMENTO")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasComment("Documento do Fornecedor");

        builder.Property(f => f.TipoFornecedor)
            .HasColumnName("FOR_TIPO")
            .HasColumnOrder(4)
            .IsRequired()
            .HasComment("Tipo do Fornecedor");

        builder.Property(f => f.Ativo)
            .HasColumnName("FOR_ATIVO")
            .HasColumnOrder(5)
            .IsRequired()
            .HasComment("Indica se o Fornecedor está Ativo");
    }
}