using Microsoft.EntityFrameworkCore;
using Vizallas.Models;

namespace Vizallas.Data
{
    public class VizallasDbContext : DbContext
    {
        public VizallasDbContext(DbContextOptions<VizallasDbContext> options) : base(options)
        {
        }
        public DbSet<Adatok> Adat { get; set; } = default!;
    }

}
