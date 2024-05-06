using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repositories;

/// <summary>
/// Repositório para manipulação de fornecedores.
/// </summary>
/// <param name="context">Contexto do banco de dados.</param>
public class FornecedorRepository(MeuDbContext context) : Repository<Fornecedor>(context), IFornecedorRepository
{
    /// <summary>
    /// Obtém um fornecedor pelo identificador com seu endereço associado.
    /// </summary>
    public async Task<Fornecedor?> ObterFornecedorComEnderecoPorIdAsync(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(f => f.Endereco) // Adiciona o endereço ao resultado da consulta
            .FirstOrDefaultAsync(f => f.Id == id); // Filtra pelo ID do fornecedor
    }

    /// <summary>
    /// Obtém um fornecedor pelo identificador com seus produtos e endereço associados.
    /// </summary>
    public async Task<Fornecedor?> ObterFornecedorComProdutosEEnderecoPorIdAsync(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(f => f.Produtos) // Adiciona os produtos ao resultado da consulta
            .Include(f => f.Endereco) // Adiciona o endereço ao resultado da consulta
            .FirstOrDefaultAsync(f => f.Id == id); // Filtra pelo ID do fornecedor
    }
}