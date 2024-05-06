using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DevIO.App.ViewModels;

namespace DevIO.App.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{

public DbSet<DevIO.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; } = default!;
}
