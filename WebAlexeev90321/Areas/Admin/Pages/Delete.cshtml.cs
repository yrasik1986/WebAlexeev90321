using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;

namespace WebAlexeev90321.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebAlexeev90321.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(WebAlexeev90321.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RadioComponent RadioComponent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RadioComponent = await _context.RadioComponents
                .Include(r => r.Group).FirstOrDefaultAsync(m => m.RadioComponentId == id);

            if (RadioComponent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RadioComponent = await _context.RadioComponents.FindAsync(id);

            if (RadioComponent != null)
            {
                _context.RadioComponents.Remove(RadioComponent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
