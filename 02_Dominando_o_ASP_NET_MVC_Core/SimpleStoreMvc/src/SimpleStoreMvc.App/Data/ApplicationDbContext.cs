using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleStoreMvc.App.ViewModels;

namespace SimpleStoreMvc.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SimpleStoreMvc.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<SimpleStoreMvc.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}