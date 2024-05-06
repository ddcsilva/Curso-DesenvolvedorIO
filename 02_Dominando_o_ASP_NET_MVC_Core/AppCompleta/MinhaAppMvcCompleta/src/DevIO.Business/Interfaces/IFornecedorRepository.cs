using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

/// <summary>
/// Interface para manipulação de repositórios de fornecedores.
/// </summary>
public interface IFornecedorRepository : IRepository<Fornecedor>
{
    /// <summary>
    /// Obtém um fornecedor pelo identificador com seu endereço associado.
    /// </summary>
    /// <param name="id">Identificador único do fornecedor.</param>
    /// <returns>Fornecedor com endereço associado.</returns>
    Task<Fornecedor?> ObterFornecedorComEnderecoPorId(Guid id);


    /// <summary>
    /// Obtém um fornecedor pelo identificador com seus produtos e endereço associados.
    /// </summary>
    /// <param name="id">Identificador único do fornecedor.</param>
    /// <returns>Fornecedor com produtos e endereço associados.</returns>
    Task<Fornecedor?> ObterFornecedorComProdutosEEnderecoPorId(Guid id);
}