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
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    /// <summary>
    /// Contexto do banco de dados usado para a manipulação das entidades.
    /// </summary>
    protected readonly MeuDbContext _context;

    /// <summary>
    /// Conjunto de entidades do tipo <typeparamref name="TEntity"/>.
    /// </summary>
    protected readonly DbSet<TEntity> _entities;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Repository{TEntity}"/>.
    /// </summary>
    /// <param name="context">Contexto do banco de dados.</param>
    protected Repository(MeuDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = context.Set<TEntity>();
    }

    /// <summary>
    /// Obtém uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade.</param>
    /// <returns>Instância de <typeparamref name="TEntity"/> correspondente ao identificador, ou <c>null</c> caso não seja encontrada.</returns>
    public virtual async Task<TEntity?> ObterPorIdAsync(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    /// <summary>
    /// Obtém todas as instâncias de <typeparamref name="TEntity"/>.
    /// </summary>
    /// <returns>Lista de todas as instâncias de <typeparamref name="TEntity"/>.</returns>
    public virtual async Task<List<TEntity>> ObterTodosAsync()
    {
        return await _entities.ToListAsync();
    }

    /// <summary>
    /// Busca instâncias de <typeparamref name="TEntity"/> que correspondam a um critério especificado.
    /// </summary>
    /// <param name="predicate">Expressão que define o critério de busca.</param>
    /// <returns>Lista de instâncias de <typeparamref name="TEntity"/> que correspondem ao critério especificado.</returns>
    public async Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.AsNoTracking().Where(predicate).ToListAsync();
    }

    /// <summary>
    /// Adiciona uma nova instância de <typeparamref name="TEntity"/> ao repositório.
    /// </summary>
    /// <param name="entity">Instância de <typeparamref name="TEntity"/> a ser adicionada.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    public virtual async Task AdicionarAsync(TEntity entity)
    {
        _entities.Add(entity);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Atualiza uma instância existente de <typeparamref name="TEntity"/> no repositório.
    /// </summary>
    /// <param name="entity">Instância de <typeparamref name="TEntity"/> a ser atualizada.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    public virtual async Task AtualizarAsync(TEntity entity)
    {
        _entities.Update(entity);
        await SaveChangesAsync();
    }

    /// <summary>
    /// Remove uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da instância de <typeparamref name="TEntity"/> a ser removida.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    public virtual async Task RemoverAsync(Guid id)
    {
        _entities.Remove(new TEntity { Id = id });
        await SaveChangesAsync();
    }

    /// <summary>
    /// Salva as alterações realizadas no contexto atual.
    /// </summary>
    /// <returns>Número de alterações salvas no banco de dados.</returns>
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
