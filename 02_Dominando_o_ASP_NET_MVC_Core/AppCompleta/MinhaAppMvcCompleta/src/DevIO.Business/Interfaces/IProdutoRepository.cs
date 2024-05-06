using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

/// <summary>
/// Interface para manipulação de repositórios de produtos.
/// </summary>
public interface IProdutoRepository : IRepository<Produto>
{
    /// <summary>
    /// Obtém um produto pelo identificador com seu fornecedor associado.
    /// </summary>
    /// <param name="id">Identificador único do produto.</param>
    /// <returns>Produto com fornecedor associado.</returns>
    Task<Produto?> ObterProdutoComFornecedorPorId(Guid id);

    /// <summary>
    /// Obtém uma lista de produtos com seus respectivos fornecedores.
    /// </summary>
    /// <returns>Lista de produtos com fornecedores associados.</returns>
    Task<IEnumerable<Produto>> ObterProdutosComFornecedores();

    /// <summary>
    /// Obtém uma lista de produtos de um fornecedor específico.
    /// </summary>
    /// <param name="fornecedorId">Identificador único do fornecedor.</param>
    /// <returns>Lista de produtos do fornecedor especificado.</returns>
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
}
