using Microsoft.EntityFrameworkCore;
using StoreAPI.Data.Configurations;
using StoreAPI.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI.Data.DAL
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext>options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);     
        }
    }
}
