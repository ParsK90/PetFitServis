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
    public class PetHayvanController : ControllerBase
    {
        private readonly PetContext _context;

        public PetHayvanController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetHayvan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetHayvan>>> GetPetHayvan()
        {
            return await _context.PetHayvan.ToListAsync();
        }

        // GET: api/PetHayvan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetHayvan>> GetPetHayvan(int id)
        {
            var petHayvan = await _context.PetHayvan.FindAsync(id);

            if (petHayvan == null)
            {
                return NotFound();
            }

            return petHayvan;
        }

        // PUT: api/PetHayvan/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetHayvan(int id, PetHayvan petHayvan)
        {
            if (id != petHayvan.Id)
            {
                return BadRequest();
            }

            _context.Entry(petHayvan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetHayvanExists(id))
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

        // POST: api/PetHayvan
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PetHayvan>> PostPetHayvan(PetHayvan petHayvan)
        {
            _context.PetHayvan.Add(petHayvan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetHayvan", new { id = petHayvan.Id }, petHayvan);
        }

        // DELETE: api/PetHayvan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetHayvan>> DeletePetHayvan(int id)
        {
            var petHayvan = await _context.PetHayvan.FindAsync(id);
            if (petHayvan == null)
            {
                return NotFound();
            }

            _context.PetHayvan.Remove(petHayvan);
            await _context.SaveChangesAsync();

            return petHayvan;
        }

        private bool PetHayvanExists(int id)
        {
            return _context.PetHayvan.Any(e => e.Id == id);
        }
    }
}
