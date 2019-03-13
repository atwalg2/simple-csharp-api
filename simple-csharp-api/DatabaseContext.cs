using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_csharp_api
{
    public class DatabaseContext: DbContext
    {
        public DbSet<users.User> users { get; set; }
        //public DbSet<OtherModel> OtherModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
                => optionsBuilder.UseNpgsql("");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("public");
        }
    }
}
