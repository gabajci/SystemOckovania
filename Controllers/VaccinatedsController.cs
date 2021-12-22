using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemOckovania.Models;
using SystemOckovanie.Models;

namespace FirmaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VaccinatedController : ControllerBase
    {
        private readonly OckovaciSystemDbContext _context;

        public VaccinatedController(OckovaciSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Vaccinated
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccinated>>> GetVaccinated()
        {
            return await _context.Vaccinated.ToListAsync();
        }

        // GET: api/Vaccinated/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccinated>> GetVaccinated(int id)
        {
            var Vaccinated = await _context.Vaccinated.FindAsync(id);

            if (Vaccinated == null)
            {
                return NotFound();
            }

            return Vaccinated;
        }

        // PUT: api/Vaccinated/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccinated(int id, Vaccinated Vaccinated)
        {
            if (id != Vaccinated.Id)
            {
                return BadRequest();
            }

            _context.Entry(Vaccinated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinatedExists(id))
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

        // POST: api/Vaccinated
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccinated>> PostVaccinated(Vaccinated Vaccinated)
        {
            _context.Vaccinated.Add(Vaccinated);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccinated", new { id = Vaccinated.Id }, Vaccinated);
        }

        // DELETE: api/Vaccinated/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinated(int id)
        {
            var Vaccinated = await _context.Vaccinated.FindAsync(id);
            if (Vaccinated == null)
            {
                return NotFound();
            }

            _context.Vaccinated.Remove(Vaccinated);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccinatedExists(int id)
        {
            return _context.Vaccinated.Any(e => e.Id == id);
        }
    }
}
