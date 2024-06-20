using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;

namespace MindMuse.AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {
        private readonly MindMuseContext _context;

        public SatelliteController(MindMuseContext context)
        {
            _context = context;
        }

        // GET: api/Satellite
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Satellite>>> GetSatellites()
        {
            return await _context.Satellites.Include(s => s.Planet).ToListAsync();
        }

        // GET: api/Satellite/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Satellite>> GetSatellite(int id)
        {
            var satellite = await _context.Satellites.FindAsync(id);

            if (satellite == null)
            {
                return NotFound();
            }

            return satellite;
        }

        // POST: api/Satellite
        [HttpPost]
        public async Task<ActionResult<Satellite>> PostSatellite(Satellite satellite)
        {
            _context.Satellites.Add(satellite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSatellite), new { id = satellite.SatelliteID }, satellite);
        }

        // PUT: api/Satellite/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSatellite(int id, Satellite satellite)
        {
            if (id != satellite.SatelliteID)
            {
                return BadRequest();
            }

            _context.Entry(satellite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SatelliteExists(id))
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

        // DELETE: api/Satellite/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSatellite(int id)
        {
            var satellite = await _context.Satellites.FindAsync(id);
            if (satellite == null)
            {
                return NotFound();
            }

            _context.Satellites.Remove(satellite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SatelliteExists(int id)
        {
            return _context.Satellites.Any(e => e.SatelliteID == id);
        }
    }
}
