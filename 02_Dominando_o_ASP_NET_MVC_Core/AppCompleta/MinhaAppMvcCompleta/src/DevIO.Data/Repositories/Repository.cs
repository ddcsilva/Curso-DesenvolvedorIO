using System.Linq.Expressions;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

/// <summary>
/// Classe base para todos os repositórios, fornecendo implementação comum.
/// </summary>
/// <typeparam name="TEntity">Tipo da entidade que o repositório manipula. Deve herdar de <see cref="Entity"/>.</typeparam>
/// <remarks>
/// Inicializa uma nova instância da classe <see cref="Repository{TEntity}"/>.
/// </remarks>
public abstract class Repository<TEntity>(MeuDbContext context) : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly MeuDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    protected readonly DbSet<TEntity> _entities = context.Set<TEntity>();

    /// <summary>
    /// Obtém uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    public virtual async Task<TEntity?> ObterPorIdAsync(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    /// <summary>
    /// Obtém todas as instâncias de <typeparamref name="TEntity"/>.
    /// </summary>
    public virtual async Task<List<TEntity>> ObterTodosAsync()
    {
        return await _entities.ToListAsync();
    }

    /// <summary>
    /// Busca instâncias de <typeparamref name="TEntity"/> que correspondam a um critério especificado.
    /// </summary>
    public async Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.AsNoTracking().Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Adiciona uma nova instância de <typeparamref name="TEntity"/> ao repositório.
    /// </summary>
    public virtual async Task AdicionarAsync(TEntity entity)
    {
        _entities.Add(entity);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Atualiza uma instância existente de <typeparamref name="TEntity"/> no repositório.
    /// </summary>
    public virtual async Task AtualizarAsync(TEntity entity)
    {
        _entities.Update(entity);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Remove uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    public virtual async Task RemoverAsync(Guid id)
    {
        _entities.Remove(new TEntity { Id = id });
        await SaveChangesAsync();
    }

    /// <summary>
    /// Salva as alterações realizadas no contexto atual.
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Libera os recursos alocados pelo contexto do banco de dados.
    /// </summary>
    public void Dispose()
    {
        _context?.Dispose();
    }
}
