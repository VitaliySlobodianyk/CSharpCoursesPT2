using Common.Models;
using Common.Models.Persons;
using Microsoft.EntityFrameworkCore;

namespace Homework6.Additional
{
    public class AppDBContext : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
