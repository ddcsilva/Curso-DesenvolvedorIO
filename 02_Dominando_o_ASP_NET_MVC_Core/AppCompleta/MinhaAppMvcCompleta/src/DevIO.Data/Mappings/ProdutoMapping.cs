using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings;

/// <summary>
/// Classe que representa o mapeamento da entidade Produto.
/// </summary>
public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    /// <summary>
    /// Método que configura o mapeamento da entidade Produto.
    /// </summary>
    /// <param name="builder">Objeto que contém as configurações da entidade Produto.</param>
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        // Configuração da Tabela
        builder.ToTable("TB_PRODUTOS", t => t.HasComment("Tabela de Produtos"));

        // Configuração da Chave Primária
        builder.HasKey(p => p.Id)
            .HasName("PK_PRODUTOS");

        // Configuração dos Relacionamentos
        builder.HasOne(p => p.Fornecedor) // Produto tem um Fornecedor
            .WithMany(f => f.Produtos) // Fornecedor tem muitos Produtos
            .HasForeignKey(p => p.FornecedorId)
            .HasConstraintName("FK_PRODUTO_FORNECEDOR");

        // Configuração dos Índices
        builder.HasIndex(p => p.Nome)
            .HasDatabaseName("IX_PRODUTOS_NOME")
            .IsUnique()
            .HasFilter("[PRO_NOME] IS NOT NULL");

        // Configuração das Propriedades
        builder.Property(p => p.Id)
            .HasColumnName("PRO_ID")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador Único do Produto");

        builder.Property(p => p.Nome)
            .HasColumnName("PRO_NOME")
            .HasColumnOrder(2)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasComment("Nome do Produto");

        builder.Property(p => p.Descricao)
            .HasColumnName("PRO_DESCRICAO")
            .HasColumnOrder(3)
            .IsRequired()
            .HasColumnType("varchar(1000)")
            .HasComment("Descrição do Produto");

        builder.Property(p => p.Imagem)
            .HasColumnName("PRO_IMAGEM")
            .HasColumnOrder(4)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasComment("Nome do Arquivo da Imagem do Produto");

        builder.Property(p => p.Valor)
            .HasColumnName("PRO_VALOR")
            .HasColumnOrder(5)
            .IsRequired()
            .HasColumnType("decimal(10, 2)")
            .HasComment("Valor do Produto");

        builder.Property(p => p.DataCadastro)
            .HasColumnName("PRO_DATA_CADASTRO")
            .HasColumnOrder(6)
            .IsRequired()
            .HasComment("Data de Cadastro do Produto");

        builder.Property(p => p.Ativo)
            .HasColumnName("PRO_ATIVO")
            .HasColumnOrder(7)
            .IsRequired()
            .HasComment("Indica se o Produto está Ativo");
    }
}
