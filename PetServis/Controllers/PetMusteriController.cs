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
    public class PetMusteriController : ControllerBase
    {
        private readonly PetContext _context;

        public PetMusteriController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetMusteri
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetMusteri>>> GetPetMusteri()
        {
            return await _context.PetMusteri.ToListAsync();
        }

        // GET: api/PetMusteri/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetMusteri>> GetPetMusteri(int id)
        {
            var petMusteri = await _context.PetMusteri.FindAsync(id);

            if (petMusteri == null)
            {
                return NotFound();
            }

            return petMusteri;
        }

        // PUT: api/PetMusteri/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetMusteri(int id, PetMusteri petMusteri)
        {
            if (id != petMusteri.Id)
            {
                return BadRequest();
            }

            _context.Entry(petMusteri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetMusteriExists(id))
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

        // POST: api/PetMusteri
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetMusteri>> PostPetMusteri(PetMusteri petMusteri)
        {
            _context.PetMusteri.Add(petMusteri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetMusteri", new { id = petMusteri.Id }, petMusteri);
        }

        // DELETE: api/PetMusteri/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetMusteri>> DeletePetMusteri(int id)
        {
            var petMusteri = await _context.PetMusteri.FindAsync(id);
            if (petMusteri == null)
            {
                return NotFound();
            }

            _context.PetMusteri.Remove(petMusteri);
            await _context.SaveChangesAsync();

            return petMusteri;
        }

        private bool PetMusteriExists(int id)
        {
            return _context.PetMusteri.Any(e => e.Id == id);
        }
    }
}
