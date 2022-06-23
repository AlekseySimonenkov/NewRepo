using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileStore.Data;
using MobileStore.Models;

namespace MobileStore.Pages.Phones
{
    public class BuyCartsController : Controller
    {
        private readonly MobileStoreContext _context;

        public BuyCartsController(MobileStoreContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public void Buy(BuyCart buycart)
        {
            _context.BuyCarts.Add(buycart);
            // сохраняем в бд все изменения
            _context.SaveChanges();
            
        }
    

    }
}
