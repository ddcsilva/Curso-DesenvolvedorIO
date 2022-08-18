using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrabalhandoComFormularios.Models;

namespace TrabalhandoComFormularios.Data
{
    public class TrabalhandoComFormulariosContext : DbContext
    {
        public TrabalhandoComFormulariosContext (DbContextOptions<TrabalhandoComFormulariosContext> options)
            : base(options)
        {
        }

        public DbSet<TrabalhandoComFormularios.Models.Filme> Filme { get; set; } = default!;
    }
}
