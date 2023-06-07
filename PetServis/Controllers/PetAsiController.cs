using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetServis.Models;

namespace PetServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetAsiController : ControllerBase
    {
        private readonly PetContext _context;

        public PetAsiController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetAsi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetAsi>>> GetPetAsi()
        {
            return await _context.PetAsi.ToListAsync();
        }

        // GET: api/PetAsi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetAsi>> GetPetAsi(int id)
        {
            var petAsi = await _context.PetAsi.FindAsync(id);

            if (petAsi == null)
            {
                return NotFound();
            }

            return petAsi;
        }

        // PUT: api/PetAsi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetAsi(int id, PetAsi petAsi)
        {
            if (id != petAsi.Id)
            {
                return BadRequest();
            }

            _context.Entry(petAsi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetAsiExists(id))
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

        // POST: api/PetAsi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetAsi>> PostPetAsi(PetAsi petAsi)
        {
            _context.PetAsi.Add(petAsi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetAsi", new { id = petAsi.Id }, petAsi);
        }

        // DELETE: api/PetAsi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetAsi>> DeletePetAsi(int id)
        {
            var petAsi = await _context.PetAsi.FindAsync(id);
            if (petAsi == null)
            {
                return NotFound();
            }

            _context.PetAsi.Remove(petAsi);
            await _context.SaveChangesAsync();

            return petAsi;
        }

        private bool PetAsiExists(int id)
        {
            return _context.PetAsi.Any(e => e.Id == id);
        }
    }
}
