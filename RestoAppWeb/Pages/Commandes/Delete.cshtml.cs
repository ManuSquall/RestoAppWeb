using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.Commandes
{
    public class DeleteModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public DeleteModel(RestoAppWeb.Data.RestoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Commande Commande { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Commandes == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes.FirstOrDefaultAsync(m => m.Id == id);

            if (commande == null)
            {
                return NotFound();
            }
            else 
            {
                Commande = commande;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Commandes == null)
            {
                return NotFound();
            }
            var commande = await _context.Commandes.FindAsync(id);

            if (commande != null)
            {
                Commande = commande;
                _context.Commandes.Remove(Commande);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
