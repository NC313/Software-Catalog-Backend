using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCatalogBackend.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Name  { get; set; } = string.Empty; //nullable
        public string? Content { get; set; } = ""; //nullable
    }
}