using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vizallas.Data;
using Vizallas.Models;

namespace Vizallas.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public DeleteModel(Vizallas.Data.VizallasDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Adatok Adatok { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adatok = await _context.Adatok.FirstOrDefaultAsync(m => m.Id == id);

            if (adatok == null)
            {
                return NotFound();
            }
            else
            {
                Adatok = adatok;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adatok = await _context.Adatok.FindAsync(id);
            if (adatok != null)
            {
                Adatok = adatok;
                _context.Adatok.Remove(Adatok);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
