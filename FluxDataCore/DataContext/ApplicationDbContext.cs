using GamesCore.ModelData;
using Microsoft.EntityFrameworkCore;

namespace FluxDataCore.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> optoins)
            : base(optoins)
            { }

        public DbSet<UpcomingGames> UpcomingGame { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
