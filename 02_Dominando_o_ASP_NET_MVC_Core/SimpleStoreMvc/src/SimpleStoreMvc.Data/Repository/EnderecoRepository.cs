using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using SimpleStoreMvc.Business.Interfaces;
using SimpleStoreMvc.Data.Context;

namespace SimpleStoreMvc.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SimpleStoreContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await context.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
