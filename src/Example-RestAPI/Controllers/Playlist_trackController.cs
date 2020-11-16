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
    public class Playlist_trackController : ControllerBase
    {
        private readonly ChinookContext _context;

        public Playlist_trackController()
        {
            _context = new ChinookContext();
        }

        // GET: api/Playlist_track
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist_track>>> GetPlaylist_track()
        {
            return await _context.Playlist_track.ToListAsync();
        }

        // GET: api/Playlist_track/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist_track>> GetPlaylist_track(int id)
        {
            var playlist_track = await _context.Playlist_track.FindAsync(id);

            if (playlist_track == null)
            {
                return NotFound();
            }

            return playlist_track;
        }

        // PUT: api/Playlist_track/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist_track(int id, Playlist_track playlist_track)
        {
            if (id != playlist_track.PlaylistID)
            {
                return BadRequest();
            }

            _context.Entry(playlist_track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Playlist_trackExists(id))
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

        // POST: api/Playlist_track
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Playlist_track>> PostPlaylist_track(Playlist_track playlist_track)
        {
            _context.Playlist_track.Add(playlist_track);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Playlist_trackExists(playlist_track.PlaylistID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlaylist_track", new { id = playlist_track.PlaylistID }, playlist_track);
        }

        // DELETE: api/Playlist_track/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Playlist_track>> DeletePlaylist_track(int id)
        {
            var playlist_track = await _context.Playlist_track.FindAsync(id);
            if (playlist_track == null)
            {
                return NotFound();
            }

            _context.Playlist_track.Remove(playlist_track);
            await _context.SaveChangesAsync();

            return playlist_track;
        }

        private bool Playlist_trackExists(int id)
        {
            return _context.Playlist_track.Any(e => e.PlaylistID == id);
        }
    }
}
