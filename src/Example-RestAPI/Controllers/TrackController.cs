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
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ChinookContext _context;

        public TrackController()
        {
            _context = new ChinookContext();
        }

        // GET: api/Track
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTrack()
        {
            return await _context.Tracks.ToListAsync();
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        [HttpGet("search/{searchby}/{term}")]
        public async Task<ActionResult<List<Track>>> SearchTracks(string searchby, string term)
        {
            string[] sanitized = term.Split("%2F");

            if (sanitized.Length > 1)
            {
                term = "";
                foreach (string s in sanitized)
                {
                    term += s + "/";
                }
                term = term.Substring(0, term.Length - 1);
            }

            if (searchby.ToLower() == "byartist")
            {
                var tracks = await _context.Tracks
                    .Where(a => a.Album.Artist.Name.ToLower() == term.ToLower()).ToListAsync<Track>();
                if (tracks == null)
                {
                    return NotFound();
                }
                else
                {
                    return tracks;
                }
            }
            if (searchby.ToLower() == "byalbum")
            {
                var tracks = await _context.Tracks
                    .Where(a => a.Album.Title.ToLower() == term.ToLower()).ToListAsync<Track>();
                if (tracks == null)
                {
                    return NotFound();
                }
                else
                {
                    return tracks;
                }
            }
            if (searchby.ToLower() == "bygenre")
            {
                var tracks = await _context.Tracks
                    .Where(a => a.Genre.Name.ToLower() == term.ToLower()).ToListAsync<Track>();
                if (tracks == null)
                {
                    return NotFound();
                }
                else
                {
                    return tracks;
                }
            }
            else return NotFound();
        }


        // PUT: api/Track/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (id != track.TrackID)
            {
                return BadRequest();
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // POST: api/Track
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrack", new { id = track.TrackID }, track);
        }

        // DELETE: api/Track/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Track>> DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return track;
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.TrackID == id);
        }
    }
}
