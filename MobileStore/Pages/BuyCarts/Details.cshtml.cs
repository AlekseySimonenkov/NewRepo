using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.BuyCarts
{
    public class DetailsModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public DetailsModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

      public BuyCart BuyCart { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BuyCarts == null)
            {
                return NotFound();
            }

            var buycart = await _context.BuyCarts.FirstOrDefaultAsync(m => m.PhoneID == id);
            if (buycart == null)
            {
                return NotFound();
            }
            else 
            {
                BuyCart = buycart;
            }
            return Page();
        }
    }
}
