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
    /// <param name="id">Identificador único do fornecedor.</param>
    /// <returns>Fornecedor com endereço associado.</returns>
    public async Task<Fornecedor?> ObterFornecedorComEnderecoPorId(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(f => f.Endereco) // Adiciona o endereço ao resultado da consulta
            .FirstOrDefaultAsync(f => f.Id == id); // Filtra pelo ID do fornecedor
    }

    /// <summary>
    /// Obtém um fornecedor pelo identificador com seus produtos e endereço associados.
    /// </summary>
    /// <param name="id">Identificador único do fornecedor.</param>
    /// <returns>Fornecedor com produtos e endereço associados.</returns>
    public async Task<Fornecedor?> ObterFornecedorComProdutosEEnderecoPorId(Guid id)
    {
        return await _entities.AsNoTracking() // Não rastreia as entidades
            .Include(f => f.Produtos) // Adiciona os produtos ao resultado da consulta
            .Include(f => f.Endereco) // Adiciona o endereço ao resultado da consulta
            .FirstOrDefaultAsync(f => f.Id == id); // Filtra pelo ID do fornecedor
    }
}