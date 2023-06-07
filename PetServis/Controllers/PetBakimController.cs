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
    public class PetBakimController : ControllerBase
    {
        private readonly PetContext _context;

        public PetBakimController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetBakim
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetBakim>>> GetPetBakim()
        {
            return await _context.PetBakim.ToListAsync();
        }

        // GET: api/PetBakim/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetBakim>> GetPetBakim(int id)
        {
            var petBakim = await _context.PetBakim.FindAsync(id);

            if (petBakim == null)
            {
                return NotFound();
            }

            return petBakim;
        }

        // PUT: api/PetBakim/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetBakim(int id, PetBakim petBakim)
        {
            if (id != petBakim.Id)
            {
                return BadRequest();
            }

            _context.Entry(petBakim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetBakimExists(id))
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

        // POST: api/PetBakim
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetBakim>> PostPetBakim(PetBakim petBakim)
        {
            _context.PetBakim.Add(petBakim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetBakim", new { id = petBakim.Id }, petBakim);
        }

        // DELETE: api/PetBakim/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetBakim>> DeletePetBakim(int id)
        {
            var petBakim = await _context.PetBakim.FindAsync(id);
            if (petBakim == null)
            {
                return NotFound();
            }

            _context.PetBakim.Remove(petBakim);
            await _context.SaveChangesAsync();

            return petBakim;
        }

        private bool PetBakimExists(int id)
        {
            return _context.PetBakim.Any(e => e.Id == id);
        }
    }
}
