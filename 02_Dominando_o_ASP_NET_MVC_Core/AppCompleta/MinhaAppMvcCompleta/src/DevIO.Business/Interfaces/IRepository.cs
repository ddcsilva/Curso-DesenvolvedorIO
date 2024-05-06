using System.Linq.Expressions;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

/// <summary>
/// Interface genérica para manipulação de repositórios.
/// </summary>
/// <typeparam name="TEntity">Tipo da entidade que o repositório manipula. Deve herdar de <see cref="Entity"/>.</typeparam>
public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    /// <summary>
    /// Obtém uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da entidade.</param>
    /// <returns>Instância de <typeparamref name="TEntity"/> correspondente ao identificador, ou <c>null</c> caso não seja encontrada.</returns>
    Task<TEntity?> ObterPorIdAsync(Guid id);

    /// <summary>
    /// Obtém todas as instâncias de <typeparamref name="TEntity"/>.
    /// </summary>
    /// <returns>Lista de todas as instâncias de <typeparamref name="TEntity"/>.</returns>
    Task<List<TEntity>> ObterTodosAsync();

    /// <summary>
    /// Busca instâncias de <typeparamref name="TEntity"/> que correspondam a um critério especificado.
    /// </summary>
    /// <param name="predicate">Expressão que define o critério de busca.</param>
    /// <returns>Lista de instâncias de <typeparamref name="TEntity"/> que correspondem ao critério especificado.</returns>
    Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Adiciona uma nova instância de <typeparamref name="TEntity"/> ao repositório.
    /// </summary>
    /// <param name="entity">Instância de <typeparamref name="TEntity"/> a ser adicionada.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    Task AdicionarAsync(TEntity entity);

    /// <summary>
    /// Atualiza uma instância existente de <typeparamref name="TEntity"/> no repositório.
    /// </summary>
    /// <param name="entity">Instância de <typeparamref name="TEntity"/> a ser atualizada.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    Task AtualizarAsync(TEntity entity);

    /// <summary>
    /// Remove uma instância de <typeparamref name="TEntity"/> pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único da instância de <typeparamref name="TEntity"/> a ser removida.</param>
    /// <returns>Tarefa assíncrona representando a operação.</returns>
    Task RemoverAsync(Guid id);

    /// <summary>
    /// Salva as alterações realizadas no contexto atual.
    /// </summary>
    /// <returns>Número de alterações salvas no banco de dados.</returns>
    Task<int> SaveChangesAsync();
}
