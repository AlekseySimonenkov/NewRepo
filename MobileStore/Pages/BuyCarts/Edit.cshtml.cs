using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.BuyCarts
{
    public class EditModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public EditModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BuyCart BuyCart { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BuyCarts == null)
            {
                return NotFound();
            }

            var buycart =  await _context.BuyCarts.FirstOrDefaultAsync(m => m.PhoneID == id);
            if (buycart == null)
            {
                return NotFound();
            }
            BuyCart = buycart;
           ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name");
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

            _context.Attach(BuyCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyCartExists(BuyCart.PhoneID))
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

        private bool BuyCartExists(int id)
        {
          return (_context.BuyCarts?.Any(e => e.PhoneID == id)).GetValueOrDefault();
        }
    }
}
