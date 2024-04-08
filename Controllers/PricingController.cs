using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareCatalogBackend.Models; 

namespace SoftwareCatalogBackend.Controllers
{
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly SoftwareCatalogDbContext _context;

        public PricingController(SoftwareCatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pricing>>> GetPricing()
        {
            return await _context.Pricing.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pricing>> GetPricing(int id)
        {
            var Pricing = await _context.Pricing.FindAsync(id);

            if (Pricing == null)
            {
                return NotFound();
            }

            return Pricing;
        }

        [HttpPost]
        public async Task<ActionResult<Pricing>> PostPricing(Pricing Pricing)
        {
            _context.Pricing.Add(Pricing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPricing), new { id = Pricing.Id }, Pricing);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPricing(int id, Pricing Pricing)
        {
            if (id != Pricing.Id)
            {
                return BadRequest();
            }

            _context.Entry(Pricing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PricingExists(id))
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
        public async Task<IActionResult> DeletePricing(int id)
        {
            var Pricing = await _context.Pricing.FindAsync(id);
            if (Pricing == null)
            {
                return NotFound();
            }

            _context.Pricing.Remove(Pricing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PricingExists(int id)
        {
            return _context.Pricing.Any(e => e.Id == id);
        }
    }
}
