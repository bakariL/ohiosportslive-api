using Microsoft.EntityFrameworkCore;

namespace FluxApiData.Data.Entities
{
    public class FluxApiDataDbContext : DbContext
    {

        public FluxApiDataDbContext(DbContextOptions<FluxApiDataDbContext> options) : base(options) 
        {

        }
        public DbSet<Upcoming_Games> Upcoming_Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //remove this line below
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
