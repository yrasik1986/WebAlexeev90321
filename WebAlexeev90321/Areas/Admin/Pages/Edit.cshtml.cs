using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;
using System.IO;

namespace WebAlexeev90321.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebAlexeev90321.DAL.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public EditModel(WebAlexeev90321.DAL.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public RadioComponent RadioComponent { get; set; }
       
        [BindProperty]
        public IFormFile Image { get; set; }

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
           ViewData["RadioComponentGroupId"] = new SelectList(_context.RadioComponentGroups, "RadioComponentGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                var fileName = $"{RadioComponent.RadioComponentId}" +
                Path.GetExtension(Image.FileName);
                RadioComponent.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }


            _context.Attach(RadioComponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadioComponentExists(RadioComponent.RadioComponentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RadioComponentExists(int id)
        {
            return _context.RadioComponents.Any(e => e.RadioComponentId == id);
        }
    }
}
