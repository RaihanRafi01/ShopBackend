using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }
       

        public DbSet<Entities.User> User { get; set; } = default!;

        public DbSet<Entities.Product>? Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer("Server=user;Initial Catalog=ShopDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;encrypt=false");
            }
        }
    }
}
