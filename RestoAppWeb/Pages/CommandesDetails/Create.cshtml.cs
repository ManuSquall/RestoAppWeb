using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.CommandesDetails
{
    public class CreateModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public CreateModel(RestoAppWeb.Data.RestoAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CommandeId"] = new SelectList(_context.Commandes, "Id", "Id");
        ViewData["ProduitId"] = new SelectList(_context.Produits, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CommandeDetail CommandeDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CommandeDetails == null || CommandeDetail == null)
            {
                return Page();
            }

            _context.CommandeDetails.Add(CommandeDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
