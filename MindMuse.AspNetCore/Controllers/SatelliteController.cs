using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Satellite>>> GetSatellites()
        {
            return await _context.Satellites.Where(s => !s.IsDeleted).ToListAsync();
        }

        [HttpGet("planet")]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            var planets = await _context.Planets.ToListAsync();
            return planets;
        }

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

        [HttpPost("CreateSatellite")]
        public async Task<ActionResult<Satellite>> CreateSatellite(Satellite satellite)
        {
            _context.Satellites.Add(satellite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSatellite), new { id = satellite.Id }, satellite);
        }

        [HttpDelete("DeleteSatellite/{id}")]
        public async Task<IActionResult> DeleteSatellite(int id)
        {
            var satellite = await _context.Satellites.FindAsync(id);
            if (satellite == null)
            {
                return NotFound();
            }

            satellite.IsDeleted = true;
            _context.Entry(satellite).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("UpdateSatelliteById/{id}")]
        public async Task<IActionResult> UpdateSatelliteById(int id, [FromBody] Satellite satellite)
        {
            if (id != satellite.Id)
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
                if (!SatelliteExist(id))
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

        private bool SatelliteExist(int id)
        {
            return _context.Satellites.Any(e => e.Id == id);
        }
    }
}
