using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.Commandes
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
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Commande Commande { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Commandes == null || Commande == null)
            {
                return Page();
            }

            _context.Commandes.Add(Commande);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
