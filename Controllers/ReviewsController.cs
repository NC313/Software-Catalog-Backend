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
    public class ReviewsController : ControllerBase
    {
        private readonly SoftwareCatalogDbContext _context;

        public ReviewsController(SoftwareCatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviews>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reviews>> GetReviews(int id)
        {
            var Reviews = await _context.Reviews.FindAsync(id);

            if (Reviews == null)
            {
                return NotFound();
            }

            return Reviews;
        }

        [HttpPost]
        public async Task<ActionResult<Reviews>> PostReviews(Reviews Reviews)
        {
            _context.Reviews.Add(Reviews);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviews), new { id = Reviews.Id }, Reviews);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviews(int id, Reviews Reviews)
        {
            if (id != Reviews.Id)
            {
                return BadRequest();
            }

            _context.Entry(Reviews).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewsExists(id))
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
        public async Task<IActionResult> DeleteReviews(int id)
        {
            var Reviews = await _context.Reviews.FindAsync(id);
            if (Reviews == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(Reviews);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
