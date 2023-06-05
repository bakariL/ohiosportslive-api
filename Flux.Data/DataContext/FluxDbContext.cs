using GamesCore.ModelData;
using Microsoft.EntityFrameworkCore;

namespace Flux.Data.DataContext
{
    public class FluxDbContext : DbContext
    {
        public FluxDbContext(DbContextOptions<FluxDbContext> options) : base(options)
        {
        }

        public DbSet<UpcomingGames> UpcomingGames { get; set; }
    }
}
