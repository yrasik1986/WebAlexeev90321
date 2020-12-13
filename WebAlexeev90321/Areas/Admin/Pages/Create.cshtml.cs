using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;

namespace WebAlexeev90321.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebAlexeev90321.DAL.Data.ApplicationDbContext _context;

        public CreateModel(WebAlexeev90321.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RadioComponentGroupId"] = new SelectList(_context.RadioComponentGroups, "RadioComponentGroupId", "RadioComponentGroupId");
            return Page();
        }

        [BindProperty]
        public RadioComponent RadioComponent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RadioComponents.Add(RadioComponent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
