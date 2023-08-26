﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoAppWeb.Data;
using RestoAppWeb.Models;

namespace RestoAppWeb.Pages.Commandes
{
    public class EditModel : PageModel
    {
        private readonly RestoAppWeb.Data.RestoAppContext _context;

        public EditModel(RestoAppWeb.Data.RestoAppContext context)
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

            var commande =  await _context.Commandes.FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }
            Commande = commande;
           ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
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

            _context.Attach(Commande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(Commande.Id))
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

        private bool CommandeExists(int id)
        {
          return (_context.Commandes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
