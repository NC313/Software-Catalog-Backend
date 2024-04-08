using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCatalogBackend.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int SoftwareId { get; set; } // Foreign key to Software
        public string? Content { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
    }
}