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
    public class AlbumController : ControllerBase
    {
        ChinookContext _context = new ChinookContext();
        public AlbumController() : base()
        {

        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            
            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            _context.Entry(album).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Album
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return album;
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
