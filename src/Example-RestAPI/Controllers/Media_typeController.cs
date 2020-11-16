using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example_RestAPI.Models;

namespace Example_RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Media_typeController : ControllerBase
    {
        private readonly ChinookContext _context;

        public Media_typeController()
        {
            _context = new ChinookContext();
        }

        // GET: api/Media_type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Media_type>>> GetMedia_types()
        {
            return await _context.Media_types.ToListAsync();
        }

        // GET: api/Media_type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Media_type>> GetMedia_type(int id)
        {
            var media_type = await _context.Media_types.FindAsync(id);

            if (media_type == null)
            {
                return NotFound();
            }

            return media_type;
        }

        // PUT: api/Media_type/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia_type(int id, Media_type media_type)
        {
            if (id != media_type.MediaTypeID)
            {
                return BadRequest();
            }

            _context.Entry(media_type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Media_typeExists(id))
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

        // POST: api/Media_type
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Media_type>> PostMedia_type(Media_type media_type)
        {
            _context.Media_types.Add(media_type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedia_type", new { id = media_type.MediaTypeID }, media_type);
        }

        // DELETE: api/Media_type/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Media_type>> DeleteMedia_type(int id)
        {
            var media_type = await _context.Media_types.FindAsync(id);
            if (media_type == null)
            {
                return NotFound();
            }

            _context.Media_types.Remove(media_type);
            await _context.SaveChangesAsync();

            return media_type;
        }

        private bool Media_typeExists(int id)
        {
            return _context.Media_types.Any(e => e.MediaTypeID == id);
        }
    }
}
