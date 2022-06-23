using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.BuyCarts
{
    public class CreateModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public CreateModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }
        public ICollection<Phone> Phones;
        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name");
            return Page();
        }

        [BindProperty]
        public BuyCart BuyCart { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BuyCarts == null || BuyCart == null)
            {
                return Page();
            }

            _context.BuyCarts.Add(BuyCart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
