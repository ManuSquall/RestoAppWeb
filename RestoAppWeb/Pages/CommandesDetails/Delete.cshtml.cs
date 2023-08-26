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
    public class DeleteModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public DeleteModel(RestoAppWeb.Data.RestoAppContext context)
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

            var commandedetail = await _context.CommandeDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (commandedetail == null)
            {
                return NotFound();
            }
            else 
            {
                CommandeDetail = commandedetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CommandeDetails == null)
            {
                return NotFound();
            }
            var commandedetail = await _context.CommandeDetails.FindAsync(id);

            if (commandedetail != null)
            {
                CommandeDetail = commandedetail;
                _context.CommandeDetails.Remove(CommandeDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
