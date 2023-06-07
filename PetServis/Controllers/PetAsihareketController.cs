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
    public class PetAsihareketController : ControllerBase
    {
        private readonly PetContext _context;

        public PetAsihareketController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetAsihareket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetAsiHareket>>> GetPetAsiHareket()
        {
            return await _context.PetAsiHareket.ToListAsync();
        }

        // GET: api/PetAsihareket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetAsiHareket>> GetPetAsiHareket(int id)
        {
            var petAsiHareket = await _context.PetAsiHareket.FindAsync(id);

            if (petAsiHareket == null)
            {
                return NotFound();
            }

            return petAsiHareket;
        }

        // PUT: api/PetAsihareket/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetAsiHareket(int id, PetAsiHareket petAsiHareket)
        {
            if (id != petAsiHareket.Id)
            {
                return BadRequest();
            }

            _context.Entry(petAsiHareket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetAsiHareketExists(id))
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

        // POST: api/PetAsihareket
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetAsiHareket>> PostPetAsiHareket(PetAsiHareket petAsiHareket)
        {
            _context.PetAsiHareket.Add(petAsiHareket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetAsiHareket", new { id = petAsiHareket.Id }, petAsiHareket);
        }

        // DELETE: api/PetAsihareket/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetAsiHareket>> DeletePetAsiHareket(int id)
        {
            var petAsiHareket = await _context.PetAsiHareket.FindAsync(id);
            if (petAsiHareket == null)
            {
                return NotFound();
            }

            _context.PetAsiHareket.Remove(petAsiHareket);
            await _context.SaveChangesAsync();

            return petAsiHareket;
        }

        private bool PetAsiHareketExists(int id)
        {
            return _context.PetAsiHareket.Any(e => e.Id == id);
        }
    }
}
