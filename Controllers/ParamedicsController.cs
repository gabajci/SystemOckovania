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
    public class ParamedicController : ControllerBase
    {
        private readonly OckovaciSystemDbContext _context;

        public ParamedicController(OckovaciSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/Paramedic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paramedic>>> GetParamedic()
        {
            return await _context.Paramedic.ToListAsync();
        }

        // GET: api/Paramedic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paramedic>> GetParamedic(int id)
        {

            var paramedicExist = _context.Account.FirstOrDefault(parX => parX.Id ==id);
            if (paramedicExist == null) {
                return null;
            }

            var Paramedic = await _context.Paramedic.FindAsync(id);

            if (Paramedic == null)
            {
                return NotFound();
            }

            return Paramedic;
        }

        // PUT: api/Paramedic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParamedic(int id, Paramedic Paramedic)
        {
            if (id != Paramedic.Id)
            {
                return BadRequest();
            }

            _context.Entry(Paramedic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamedicExists(id))
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

        // POST: api/Paramedic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Paramedic>> PostParamedic(Paramedic Paramedic)
        {
            _context.Paramedic.Add(Paramedic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParamedic", new { id = Paramedic.Id }, Paramedic);
        }

        // DELETE: api/Paramedic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParamedic(int id)
        {
            var Paramedic = await _context.Paramedic.FindAsync(id);
            if (Paramedic == null)
            {
                return NotFound();
            }

            _context.Paramedic.Remove(Paramedic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParamedicExists(int id)
        {
            return _context.Paramedic.Any(e => e.Id == id);
        }
    }
}
