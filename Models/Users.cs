using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCatalogBackend.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; } = ""; //nullable
        public string Email { get; set; } = ""; //nullable
    }
}