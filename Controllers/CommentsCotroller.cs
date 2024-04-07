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
    public class CommentsController : ControllerBase
    {
        private readonly SoftwareCatalogDbContext _context;

        public CommentsController(SoftwareCatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comments>> GetComments(int id)
        {
            var Comments = await _context.Comments.FindAsync(id);

            if (Comments == null)
            {
                return NotFound();
            }

            return Comments;
        }

        [HttpPost]
        public async Task<ActionResult<Comments>> PostComments(Comments Comments)
        {
            _context.Comments.Add(Comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComments), new { id = Comments.Id }, Comments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments(int id, Comments Comments)
        {
            if (id != Comments.Id)
            {
                return BadRequest();
            }

            _context.Entry(Comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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
        public async Task<IActionResult> DeleteComments(int id)
        {
            var Comments = await _context.Comments.FindAsync(id);
            if (Comments == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(Comments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
