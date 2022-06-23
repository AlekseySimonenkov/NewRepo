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

namespace MobileStore.Pages.Phones
{
    public class EditModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public EditModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; }
        public BuyCart BuyCart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }

            var phone =  await _context.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            Phone = phone;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var phoneToUpdate = await _context.Phones.FindAsync(id);
            
            if (phoneToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Phone>(
        phoneToUpdate,
        "phone",
        s => s.Firm, s => s.Model, s => s.Price))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PhoneExists(int id)
        {
          return (_context.Phone?.Any(e => e.PhoneID == id)).GetValueOrDefault();
        }
    }
}
