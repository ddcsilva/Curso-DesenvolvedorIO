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
    public async Task<Produto?> ObterProdutoComFornecedorPorIdAsync(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(p => p.Fornecedor) // Adiciona o fornecedor ao resultado da consulta
            .FirstOrDefaultAsync(p => p.Id == id); // Filtra pelo ID do produto
    }

    /// <summary>
    /// Obtém uma lista de produtos com seus respectivos fornecedores.
    /// </summary>
    public async Task<IEnumerable<Produto>> ObterProdutosComFornecedoresAsync()
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(p => p.Fornecedor) // Adiciona o fornecedor ao resultado da consulta
            .ToListAsync(); // Retorna a lista de produtos
    }

    /// <summary>
    /// Obtém uma lista de produtos de um fornecedor específico.
    /// </summary>
    public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedorAsync(Guid fornecedorId)
    {
        return await BuscarAsync(p => p.FornecedorId == fornecedorId); // Busca os produtos do fornecedor especificado
    }
}