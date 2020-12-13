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
    public class IndexModel : PageModel
    {
        private readonly WebAlexeev90321.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebAlexeev90321.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<RadioComponent> RadioComponent { get;set; }

        public async Task OnGetAsync()
        {
            RadioComponent = await _context.RadioComponents
                .Include(r => r.Group).ToListAsync();
        }
    }
}
