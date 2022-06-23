using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.Phones
{
    public class DetailsModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public DetailsModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

      public AboutPhone AboutPhones { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AboutPhones == null)
            {
                return NotFound();
            }

            var aboutphone = await _context.AboutPhones.FirstOrDefaultAsync(m => m.AboutPhoneID == id);
            if (aboutphone == null)
            {
                return NotFound();
            }
            else 
            {
                AboutPhones = aboutphone;
            }
            return Page();
        }
    }
}
