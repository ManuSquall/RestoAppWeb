using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.Produits
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
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Produits == null || Produit == null)
            {
                return Page();
            }

            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
