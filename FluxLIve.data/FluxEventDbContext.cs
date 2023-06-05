using FluxLive.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxLIve.data
{
    public class FluxEventDbContext : DbContext
    {

        public FluxEventDbContext(DbContextOptions<FluxEventDbContext> options)
            :base(options)
        {

        }
        public DbSet<FluxEvent> FluxEvents { get; set; }
    }
}
