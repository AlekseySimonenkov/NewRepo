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

namespace MobileStore.Pages.Clients
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

        public string NameSort { get; set; }
        public string AddressSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Client> Clients { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            AddressSort = sortOrder == "Address" ? "address_desc" : "Address";
            CurrentFilter = searchString;

            IQueryable<Client> clientsAd= from s in _context.Clients
                                          select s;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                clientsAd = clientsAd.Where(s => s.Name.Contains(searchString)
                                       || s.Address.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clientsAd = clientsAd.OrderByDescending(s => s.Name); ;
                    break;
                case "Address":
                    clientsAd = clientsAd.OrderBy(s => s.Name);
                    break;
                case "address_desc":
                    clientsAd = clientsAd.OrderByDescending(s => s.Address);
                    break;
                default:
                    clientsAd = clientsAd.OrderBy(s => s.Address);
                    break;
            }
            var pageSize = Configuration.GetValue("PageSize", 4);
            Clients = await PaginatedList<Client>.CreateAsync(clientsAd.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
