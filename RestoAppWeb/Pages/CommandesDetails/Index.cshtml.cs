using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.CommandesDetails
{
    public class IndexModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public IndexModel(RestoAppWeb.Data.RestoAppContext context)
        {
            _context = context;
        }

        public IList<CommandeDetail> CommandeDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CommandeDetails != null)
            {
                CommandeDetail = await _context.CommandeDetails
                .Include(c => c.Commande)
                .Include(c => c.Produit).ToListAsync();
            }
        }
    }
}
