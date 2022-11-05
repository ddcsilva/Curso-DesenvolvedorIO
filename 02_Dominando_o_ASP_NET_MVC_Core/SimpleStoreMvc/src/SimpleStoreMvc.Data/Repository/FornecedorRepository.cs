using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using SimpleStoreMvc.Business.Interfaces;
using SimpleStoreMvc.Data.Context;

namespace SimpleStoreMvc.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SimpleStoreContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await context.Fornecedores.AsNoTracking()
                .Include(p => p.Produtos)
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
