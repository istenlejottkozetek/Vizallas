using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vizallas.Data;
using Vizallas.Models;

namespace Vizallas.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public CreateModel(Vizallas.Data.VizallasDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Adatok Adatok { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Adatok.Add(Adatok);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
