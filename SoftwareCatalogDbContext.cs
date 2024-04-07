using ResumeProjects.SoftwareCatalogBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace SoftwareCatalogBackend
{
    public class SoftwareCatalogDbContext : DbContext
    {
        public SoftwareCatalogDbContext(DbContextOptions<SoftwareCatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Software>? Softwares { get; set; }
    }
}