using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

/// <summary>
/// Repositório para manipulação de endereços.
/// </summary>
/// <param name="context">Contexto do banco de dados.</param>
public class EnderecoRepository(MeuDbContext context) : Repository<Endereco>(context), IEnderecoRepository
{
    /// <summary>
    /// Obtém um endereço pelo identificador do fornecedor associado.
    /// </summary>
    public async Task<Endereco?> ObterEnderecoPorFornecedor(Guid fornecedorId)
    {
        return await _context.Enderecos.AsNoTracking() // Não rastreia as entidades
            .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId); // Filtra pelo ID do fornecedor
    }
}