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
    public class IndexModel : PageModel
    {
        private readonly Vizallas.Data.VizallasDbContext _context;

        public IndexModel(Vizallas.Data.VizallasDbContext context)
        {
            _context = context;
        }

        public IList<Adatok> Adatok { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Adatok = await _context.Adatok.ToListAsync();
        }
    }
}
