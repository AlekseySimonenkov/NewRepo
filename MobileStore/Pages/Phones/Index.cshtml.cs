using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;
using Microsoft.Extensions.Configuration;

namespace MobileStore.Pages.Phones
{
    public class IndexModel : PageModel
    {
        private readonly MobileStoreContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(MobileStoreContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string FirmSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Phone> Phones { get; set; }
        public BuyCart BuyCart { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            //сортировка 
            FirmSort = String.IsNullOrEmpty(sortOrder) ? "firm_desc" : "";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            CurrentFilter = searchString;

            IQueryable<Phone> phonesCPU = from s in _context.Phones
                                             select s;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                //фильтрация по поисковой строке
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                phonesCPU = phonesCPU.Where(s => s.Firm.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "firm_desc":
                    phonesCPU = phonesCPU.OrderByDescending(s => s.Firm); ;
                    break;
                case "Price":
                    phonesCPU = phonesCPU.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    phonesCPU = phonesCPU.OrderByDescending(s => s.Price);
                    break;
                default:
                    phonesCPU = phonesCPU.OrderBy(s => s.Firm);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 4);
            Phones = await PaginatedList<Phone>.CreateAsync(phonesCPU.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
