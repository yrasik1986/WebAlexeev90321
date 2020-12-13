using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using WebAlexeev90321.DAL.Data;
using WebAlexeev90321.DAL.Entities;
using System.IO;

namespace WebAlexeev90321.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebAlexeev90321.DAL.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CreateModel(WebAlexeev90321.DAL.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["RadioComponentGroupId"] = new SelectList(_context.RadioComponentGroups, "RadioComponentGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public RadioComponent RadioComponent { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

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
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
