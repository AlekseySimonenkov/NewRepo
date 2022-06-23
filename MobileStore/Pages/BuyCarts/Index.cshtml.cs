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
    public class IndexModel : PageModel
    {
        private readonly MobileStore.Data.MobileStoreContext _context;

        public IndexModel(MobileStore.Data.MobileStoreContext context)
        {
            _context = context;
        }

        public IList<Phone> Phones { get; set; }
        public IList<BuyCart> BuyCart { get;set; } 

        public async Task OnGetAsync()
        {
            if (_context.BuyCarts != null)
            {
                BuyCart = await _context.BuyCarts
                .Include(b => b.Client).ToListAsync();
            }
        }
    }
}
