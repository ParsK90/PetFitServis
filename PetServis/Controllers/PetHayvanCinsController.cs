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
    public class PetHayvanCinsController : ControllerBase
    {
        private readonly PetContext _context;

        public PetHayvanCinsController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetHayvanCins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetHayvanCins>>> GetPetHayvanCins()
        {
            return await _context.PetHayvanCins.ToListAsync();
        }

        // GET: api/PetHayvanCins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetHayvanCins>> GetPetHayvanCins(int id)
        {
            var petHayvanCins = await _context.PetHayvanCins.FindAsync(id);

            if (petHayvanCins == null)
            {
                return NotFound();
            }

            return petHayvanCins;
        }

        // PUT: api/PetHayvanCins/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetHayvanCins(int id, PetHayvanCins petHayvanCins)
        {
            if (id != petHayvanCins.Id)
            {
                return BadRequest();
            }

            _context.Entry(petHayvanCins).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetHayvanCinsExists(id))
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

        // POST: api/PetHayvanCins
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetHayvanCins>> PostPetHayvanCins(PetHayvanCins petHayvanCins)
        {
            _context.PetHayvanCins.Add(petHayvanCins);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetHayvanCinsExists(petHayvanCins.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPetHayvanCins", new { id = petHayvanCins.Id }, petHayvanCins);
        }

        // DELETE: api/PetHayvanCins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetHayvanCins>> DeletePetHayvanCins(int id)
        {
            var petHayvanCins = await _context.PetHayvanCins.FindAsync(id);
            if (petHayvanCins == null)
            {
                return NotFound();
            }

            _context.PetHayvanCins.Remove(petHayvanCins);
            await _context.SaveChangesAsync();

            return petHayvanCins;
        }

        private bool PetHayvanCinsExists(int id)
        {
            return _context.PetHayvanCins.Any(e => e.Id == id);
        }
    }
}
