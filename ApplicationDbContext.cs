using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCatalogBackend
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

        private DbSet<Software> softwares;

        public DbSet<Software> GetSoftwares()
        {
            return softwares;
        }

        public void SetSoftwares(DbSet<Software> value)
        {
            softwares = value;
        }
    }
}