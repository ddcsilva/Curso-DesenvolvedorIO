using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context;

/// <summary>
/// Classe que representa o contexto do banco de dados.
/// </summary>
public class MeuDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    /// <summary>
    /// Método que é chamado quando o modelo é criado.
    /// </summary>
    /// <param name="modelBuilder"> Objeto que contém as configurações do modelo. </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração do tipo de dados para VARCHAR(100). Ele faz o seguinte:
        // - Procura por propriedades que são do tipo string
        // - Configura o tipo de dado para VARCHAR(100)
        // - Isso evita que o Entity Framework crie colunas do tipo NVARCHAR(MAX)
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()).Where(p => p.ClrType == typeof(string)))
        {
            property.SetColumnType("varchar(100)");
        }

        // Aplica as configurações de mapeamento. Ele faz o seguinte:
        // - Procura por classes que implementam IEntityTypeConfiguration<T>
        // - Cria uma instância dessas classes
        // - Chama o método Configure() de cada uma dessas instâncias
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

        // Configuração do DeleteBehavior para ClientSetNull. Ele faz o seguinte:
        // - Quando um registro é deletado, as propriedades que são FKs são setadas como NULL
        // - Isso evita que o registro seja deletado caso ele tenha FKs
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        base.OnModelCreating(modelBuilder);
    }
}
