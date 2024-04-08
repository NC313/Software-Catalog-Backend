using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareCatalogBackend.Models; 

namespace SoftwareCatalogBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly SoftwareCatalogDbContext _context;

        public SoftwareController(SoftwareCatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Software>>> GetSoftware()
        {
            return await _context.Software.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Software>> GetSoftware(int id)
        {
            var software = await _context.Software.FindAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            return software;
        }

        [HttpPost]
        public async Task<ActionResult<Software>> PostSoftware(Software software)
        {
            _context.Software.Add(software);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSoftware), new { id = software.Id }, software);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftware(int id, Software software)
        {
            if (id != software.Id)
            {
                return BadRequest();
            }

            _context.Entry(software).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            var software = await _context.Software.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            _context.Software.Remove(software);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftwareExists(int id)
        {
            return _context.Software.Any(e => e.Id == id);
        }
    }
}
