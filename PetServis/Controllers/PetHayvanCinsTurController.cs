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
    public class PetHayvanCinsTurController : ControllerBase
    {
        private readonly PetContext _context;

        public PetHayvanCinsTurController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetHayvanCinsTur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetHayvanCinsTur>>> GetPetHayvanCinsTur()
        {
            return await _context.PetHayvanCinsTur.ToListAsync();
        }

        // GET: api/PetHayvanCinsTur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetHayvanCinsTur>> GetPetHayvanCinsTur(int id)
        {
            var petHayvanCinsTur = await _context.PetHayvanCinsTur.FindAsync(id);

            if (petHayvanCinsTur == null)
            {
                return NotFound();
            }

            return petHayvanCinsTur;
        }

        // PUT: api/PetHayvanCinsTur/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetHayvanCinsTur(int id, PetHayvanCinsTur petHayvanCinsTur)
        {
            if (id != petHayvanCinsTur.Id)
            {
                return BadRequest();
            }

            _context.Entry(petHayvanCinsTur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetHayvanCinsTurExists(id))
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

        // POST: api/PetHayvanCinsTur
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetHayvanCinsTur>> PostPetHayvanCinsTur(PetHayvanCinsTur petHayvanCinsTur)
        {
            _context.PetHayvanCinsTur.Add(petHayvanCinsTur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PetHayvanCinsTurExists(petHayvanCinsTur.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPetHayvanCinsTur", new { id = petHayvanCinsTur.Id }, petHayvanCinsTur);
        }

        // DELETE: api/PetHayvanCinsTur/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetHayvanCinsTur>> DeletePetHayvanCinsTur(int id)
        {
            var petHayvanCinsTur = await _context.PetHayvanCinsTur.FindAsync(id);
            if (petHayvanCinsTur == null)
            {
                return NotFound();
            }

            _context.PetHayvanCinsTur.Remove(petHayvanCinsTur);
            await _context.SaveChangesAsync();

            return petHayvanCinsTur;
        }

        private bool PetHayvanCinsTurExists(int id)
        {
            return _context.PetHayvanCinsTur.Any(e => e.Id == id);
        }
    }
}
