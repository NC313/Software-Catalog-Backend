using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Software-Catalog-Backend.Controllers
{
    [Route("[controller]")]
    public class CommentsCotroller : Controller
    {
        private readonly ILogger<CommentsCotroller> _logger;

        public CommentsCotroller(ILogger<CommentsCotroller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}