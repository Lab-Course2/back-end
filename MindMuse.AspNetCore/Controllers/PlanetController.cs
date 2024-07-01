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
    public class PlanetController : ControllerBase
    {
        private readonly MindMuseContext _context;

        public PlanetController(MindMuseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            return await _context.Planets.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetPlanet")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            return planet;
        }

        [HttpPost("CreatePlanet")]
        public async Task<ActionResult<Planet>> CreatePlanet(Planet planet)
        {
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetPlanet", new { id = planet.Id }, planet);
        }

        [HttpDelete("DeletePlanet/{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            var planet = await _context.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }

            planet.isDeleted = true;
            _context.Entry(planet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("UpdatePlanetById/{id}")]
        public async Task<IActionResult> UpdatePlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return BadRequest();
            }

            _context.Entry(planet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExist(id))
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

        private bool PlanetExist(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
