using System;
using System.Collections.Generic;
// Author: Choudhury Saadmaan Mahmid
// Created: July 12, 2025
// Description: Controller for handling movie http requests.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMDBMovieAPI.Models;

namespace IMDBMovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopMovies2025Controller : ControllerBase
    {
        private readonly MovieDbContext _context;

        public TopMovies2025Controller(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/TopMovies2025
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopMovies2025>>> GetTopMovies2025s()
        {
            return await _context.TopMovies2025s.ToListAsync();
        }

        // GET: api/TopMovies2025/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopMovies2025>> GetTopMovies2025(int id)
        {
            var topMovies2025 = await _context.TopMovies2025s.FindAsync(id);

            if (topMovies2025 == null)
            {
                return NotFound();
            }

            return topMovies2025;
        }

        // PUT: api/TopMovies2025/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopMovies2025(int id, TopMovies2025 topMovies2025)
        {
            if (id != topMovies2025.Rank)
            {
                return BadRequest();
            }

            _context.Entry(topMovies2025).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopMovies2025Exists(id))
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

        // POST: api/TopMovies2025
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TopMovies2025>> PostTopMovies2025(TopMovies2025 topMovies2025)
        {
            _context.TopMovies2025s.Add(topMovies2025);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TopMovies2025Exists(topMovies2025.Rank))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopMovies2025", new { id = topMovies2025.Rank }, topMovies2025);
        }

        // DELETE: api/TopMovies2025/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopMovies2025(int id)
        {
            var topMovies2025 = await _context.TopMovies2025s.FindAsync(id);
            if (topMovies2025 == null)
            {
                return NotFound();
            }

            _context.TopMovies2025s.Remove(topMovies2025);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopMovies2025Exists(int id)
        {
            return _context.TopMovies2025s.Any(e => e.Rank == id);
        }
    }
}
