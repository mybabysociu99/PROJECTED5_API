using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECTED5.Models;

namespace PROJECTED5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public ScoresController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scores>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scores>> GetScores(string id)
        {
            var scores = await _context.Scores.FindAsync(id);

            if (scores == null)
            {
                return NotFound();
            }

            return scores;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScores(string id, Scores scores)
        {
            if (id != scores.ScoresId)
            {
                return BadRequest();
            }

            _context.Entry(scores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoresExists(id))
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

        // POST: api/Scores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Scores>> PostScores(Scores scores)
        {
            _context.Scores.Add(scores);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScoresExists(scores.ScoresId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScores", new { id = scores.ScoresId }, scores);
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scores>> DeleteScores(string id)
        {
            var scores = await _context.Scores.FindAsync(id);
            if (scores == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(scores);
            await _context.SaveChangesAsync();

            return scores;
        }

        private bool ScoresExists(string id)
        {
            return _context.Scores.Any(e => e.ScoresId == id);
        }
    }
}
