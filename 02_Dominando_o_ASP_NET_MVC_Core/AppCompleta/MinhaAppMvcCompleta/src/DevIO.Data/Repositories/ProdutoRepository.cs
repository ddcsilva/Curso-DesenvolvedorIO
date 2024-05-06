using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

/// <summary>
/// Repositório para manipulação de produtos.
/// </summary>
/// <param name="context">Contexto do banco de dados.</param>
public class ProdutoRepository(MeuDbContext context) : Repository<Produto>(context), IProdutoRepository
{
    /// <summary>
    /// Obtém um produto pelo identificador com seu fornecedor associado.
    /// </summary>
    /// <param name="id">Identificador único do produto.</param>
    /// <returns>Produto com fornecedor associado.</returns>
    public async Task<Produto?> ObterProdutoComFornecedorPorId(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(p => p.Fornecedor) // Adiciona o fornecedor ao resultado da consulta
            .FirstOrDefaultAsync(p => p.Id == id); // Filtra pelo ID do produto
    }

    /// <summary>
    /// Obtém uma lista de produtos com seus respectivos fornecedores.
    /// </summary>
    /// <returns>Lista de produtos com fornecedores associados.</returns>
    public async Task<IEnumerable<Produto>> ObterProdutosComFornecedores()
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(p => p.Fornecedor) // Adiciona o fornecedor ao resultado da consulta
            .ToListAsync(); // Retorna a lista de produtos
    }

    /// <summary>
    /// Obtém uma lista de produtos de um fornecedor específico.
    /// </summary>
    /// <param name="fornecedorId">Identificador único do fornecedor.</param>
    /// <returns>Lista de produtos do fornecedor especificado.</returns>
    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
    {
        return await BuscarAsync(p => p.FornecedorId == fornecedorId); // Busca os produtos do fornecedor especificado
    }
}