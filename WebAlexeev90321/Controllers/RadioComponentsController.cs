using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;

namespace WebAlexeev90321.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadioComponentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RadioComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RadioComponents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RadioComponent>>> GetRadioComponents(int? group)
        {
            return await _context.RadioComponents.Where(d => !group.HasValue || d.RadioComponentGroupId.Equals(group.Value))?.ToListAsync();
        }

        // GET: api/RadioComponents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RadioComponent>> GetRadioComponent(int id)
        {
            var radioComponent = await _context.RadioComponents.FindAsync(id);

            if (radioComponent == null)
            {
                return NotFound();
            }

            return radioComponent;
        }

        // PUT: api/RadioComponents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRadioComponent(int id, RadioComponent radioComponent)
        {
            if (id != radioComponent.RadioComponentId)
            {
                return BadRequest();
            }

            _context.Entry(radioComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadioComponentExists(id))
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

        // POST: api/RadioComponents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RadioComponent>> PostRadioComponent(RadioComponent radioComponent)
        {
            _context.RadioComponents.Add(radioComponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRadioComponent", new { id = radioComponent.RadioComponentId }, radioComponent);
        }

        // DELETE: api/RadioComponents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RadioComponent>> DeleteRadioComponent(int id)
        {
            var radioComponent = await _context.RadioComponents.FindAsync(id);
            if (radioComponent == null)
            {
                return NotFound();
            }

            _context.RadioComponents.Remove(radioComponent);
            await _context.SaveChangesAsync();

            return radioComponent;
        }

        private bool RadioComponentExists(int id)
        {
            return _context.RadioComponents.Any(e => e.RadioComponentId == id);
        }
    }
}
