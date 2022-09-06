using Microsoft.AspNetCore.Mvc;
using OpustecCodeTest2.Data;
using OpustecCodeTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpustecCodeTest2.Controllers
{
    public class SalesController : Controller
    {
        private ApplicationDbContext _db;
        public SalesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult getProducts(int id)
        {
            List<Product> products = new List<Product>();
            
                products = _db.Products.Where(a => a.Id.Equals(id)).OrderBy(a => a.ProductName).ToList();

            return Json(products, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
