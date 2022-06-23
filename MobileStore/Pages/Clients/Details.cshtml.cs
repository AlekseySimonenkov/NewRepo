using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public DetailsModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

      public AboutClient AboutClient { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AboutClient == null)
            {
                return NotFound();
            }

            var aboutclient = await _context.AboutClient.FirstOrDefaultAsync(m => m.AboutClientID == id);
            if (aboutclient == null)
            {
                return NotFound();
            }
            else 
            {
                AboutClient = aboutclient;
            }
            return Page();
        }
    }
}
