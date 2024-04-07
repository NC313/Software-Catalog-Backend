using SoftwareCatalogBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace SoftwareCatalogBackend
{
    public class SoftwareCatalogDbContext : DbContext
    {
        public SoftwareCatalogDbContext(DbContextOptions<SoftwareCatalogDbContext> options) : base(options)
        {
        }

         public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Pricing> Pricing { get; set; }
    }
}