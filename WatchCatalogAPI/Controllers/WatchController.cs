using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchCatalogAPI.Models;

namespace WatchCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly WatchDBContext _context;

        public WatchController(WatchDBContext context)
        {
            _context = context;
        }

        // GET: api/Watch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Watch>>> GetWatches()
        {
            return await _context.Watches.ToListAsync();
        }

        // GET: api/Watch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Watch>> GetWatch(int id)
        {
            var watch = await _context.Watches.FindAsync(id);

            if (watch == null)
            {
                return NotFound();
            }

            return watch;
        }

        // PUT: api/Watch/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatch(int id, Watch watch)
        {
            if (id != watch.WatchId)
            {
                return BadRequest();
            }

            _context.Entry(watch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchExists(id))
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

        // POST: api/Watch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Watch>> PostWatch(Watch watch)
        {
            _context.Watches.Add(watch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatch", new { id = watch.WatchId }, watch);
        }

        // DELETE: api/Watch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatch(int id)
        {
            var watch = await _context.Watches.FindAsync(id);
            if (watch == null)
            {
                return NotFound();
            }

            _context.Watches.Remove(watch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchExists(int id)
        {
            return _context.Watches.Any(e => e.WatchId == id);
        }
    }
}
