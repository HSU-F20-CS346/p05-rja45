﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example_RestAPI.Models;

namespace Example_RestAPI.Controllers
{
    /// <summary>
    /// Generated using VS2019's auto generator tool
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        ChinookContext _context = new ChinookContext();
        public ArtistController() :base()
        {

        }

        // GET: api/Artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            //use Include to have EF also query Album information.  Leaving it out makes the field NULL
            var artist = await _context.Artists.Include("Albums").Where(a => a.ArtistId == id).FirstOrDefaultAsync();
            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // GET: api/Artist/search/byAlbum/<albumName>
        [HttpGet("search/byAlbum/{albumName}")]
        public async Task<ActionResult<Artist>> GetArtistByAlbum(string albumName)
        {
            //use Include to have EF also query Album information.  Leaving it out makes the field NULL
            var artist = await _context.Artists
                .Include("Albums")
                .Where(a => a.Albums.Any(x => x.Title.ToLower() == albumName.ToLower()))
                .FirstOrDefaultAsync();

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        [HttpGet("Search/byGenre/{genreName}")]
        public async Task<ActionResult<List<Artist>>> SearchArtistByGenre(string genreName)
        {
            var artist = await _context.Artists
                .Where(a => a.Albums.Any(b => b.Tracks.Any(t => t.Genre.Name.ToLower() == genreName.ToLower())))
                .ToListAsync<Artist>();
            if (artist == null)
            {
                return NotFound();
            }
            return artist;
        }


        // PUT: api/Artist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }

        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
