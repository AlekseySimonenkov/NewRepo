using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.Phones
{
    public class CreateModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public CreateModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Phone Phone { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPhone = new Phone();

            if (await TryUpdateModelAsync<Phone>(
                emptyPhone,
                "phone",   // Prefix for form value.
                s => s.Firm, s => s.Model, s => s.Price))
            {
                _context.Phones.Add(emptyPhone);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
