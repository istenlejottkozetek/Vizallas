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
    public class FolyoszuresModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public FolyoszuresModel(Vizallas.Data.VizallasDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int KivalasztottFolyo { get; set; }

        public IList<Adatok> Adatok { get;set; } = default!;
        public IList<int> Folyok { get; set; } = default!;

        public async Task OnGetAsync()
        {
           Folyok = await _context.Adat
                .Select(a => a.folyo)
                .Distinct()
                .OrderBy(f => f)
                .ToListAsync();

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (KivalasztottFolyo == null)
            {
                KivalasztottFolyo = Folyok.FirstOrDefault();
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            Adatok = await _context.Adat
                .Where(a => a.folyo == KivalasztottFolyo)
                .ToListAsync();
        }
    }
}
