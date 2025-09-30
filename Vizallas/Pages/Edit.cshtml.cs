using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vizallas.Data;
using Vizallas.Models;

namespace Vizallas.Pages
{
    public class EditModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public EditModel(Vizallas.Data.VizallasDbContext context)
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

            var adatok =  await _context.Adat.FirstOrDefaultAsync(m => m.Id == id);
            if (adatok == null)
            {
                return NotFound();
            }
            Adatok = adatok;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Adatok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdatokExists(Adatok.Id))
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

        private bool AdatokExists(int id)
        {
            return _context.Adat.Any(e => e.Id == id);
        }
    }
}
