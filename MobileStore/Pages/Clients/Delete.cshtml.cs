﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public DeleteModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Client Client { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientID == id);

            if (client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = client;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);

            if (client != null)
            {
                Client = client;
                _context.Clients.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
