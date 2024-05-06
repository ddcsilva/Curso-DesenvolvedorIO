using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

/// <summary>
/// Interface para manipulação de repositórios de endereços.
/// </summary>
public interface IEnderecoRepository : IRepository<Endereco>
{
    /// <summary>
    /// Obtém um endereço pelo identificador do fornecedor associado.
    /// </summary>
    /// <param name="fornecedorId">Identificador único do fornecedor.</param>
    /// <returns>Endereço do fornecedor especificado.</returns>
    Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId);
}
