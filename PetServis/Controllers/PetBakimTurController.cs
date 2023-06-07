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
    public class PetBakimTurController : ControllerBase
    {
        private readonly PetContext _context;

        public PetBakimTurController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetBakimTur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetBakimTur>>> GetPetBakimTur()
        {
            return await _context.PetBakimTur.ToListAsync();
        }

        // GET: api/PetBakimTur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetBakimTur>> GetPetBakimTur(int id)
        {
            var petBakimTur = await _context.PetBakimTur.FindAsync(id);

            if (petBakimTur == null)
            {
                return NotFound();
            }

            return petBakimTur;
        }

        // PUT: api/PetBakimTur/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetBakimTur(int id, PetBakimTur petBakimTur)
        {
            if (id != petBakimTur.Id)
            {
                return BadRequest();
            }

            _context.Entry(petBakimTur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetBakimTurExists(id))
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

        // POST: api/PetBakimTur
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetBakimTur>> PostPetBakimTur(PetBakimTur petBakimTur)
        {
            _context.PetBakimTur.Add(petBakimTur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetBakimTurExists(petBakimTur.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPetBakimTur", new { id = petBakimTur.Id }, petBakimTur);
        }

        // DELETE: api/PetBakimTur/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetBakimTur>> DeletePetBakimTur(int id)
        {
            var petBakimTur = await _context.PetBakimTur.FindAsync(id);
            if (petBakimTur == null)
            {
                return NotFound();
            }

            _context.PetBakimTur.Remove(petBakimTur);
            await _context.SaveChangesAsync();

            return petBakimTur;
        }

        private bool PetBakimTurExists(int id)
        {
            return _context.PetBakimTur.Any(e => e.Id == id);
        }
    }
}
