using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.CommandesDetails
{
    public class EditModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public EditModel(RestoAppWeb.Data.RestoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CommandeDetail CommandeDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CommandeDetails == null)
            {
                return NotFound();
            }

            var commandedetail =  await _context.CommandeDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (commandedetail == null)
            {
                return NotFound();
            }
            CommandeDetail = commandedetail;
           ViewData["CommandeId"] = new SelectList(_context.Commandes, "Id", "Id");
           ViewData["ProduitId"] = new SelectList(_context.Produits, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CommandeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeDetailExists(CommandeDetail.Id))
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

        private bool CommandeDetailExists(int id)
        {
          return (_context.CommandeDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
