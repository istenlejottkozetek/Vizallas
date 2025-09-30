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
    public class VarosszuresModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public VarosszuresModel(Vizallas.Data.VizallasDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int KivalasztottVaros { get; set; }
        public IList<Adatok> Adatok { get;set; } = default!;
        public IList<int> Varos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Varos = await _context.Adat
                .Select(a => a.varos)
                .Distinct()
                .OrderBy(f => f)
                .ToListAsync();

           
            if (KivalasztottVaros == 0 && Varos.Any())
            {
                KivalasztottVaros = Varos.FirstOrDefault();
            }

            Adatok = await _context.Adat
                .Where(a => a.varos == KivalasztottVaros)
                .ToListAsync();
        }
}
}

