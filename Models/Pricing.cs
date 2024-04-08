using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCatalogBackend.Models
{
    public class Pricing
    {
         public int Id { get; set; }
        public int SoftwareId { get; set; } // Foreign key to Software
        public string? PlanName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}