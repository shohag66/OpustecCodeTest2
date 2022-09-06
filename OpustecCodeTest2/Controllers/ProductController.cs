using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpustecCodeTest2.Data;
using OpustecCodeTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpustecCodeTest2.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)

                {
                     _db.Products.Add(model);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    
                }

                return View();


            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exist = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _db.Products.Where(x => x.Id == product.Id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if (exist != null)
                    {
                        exist.ProductCode = product.ProductCode;
                        exist.ProductName = product.ProductName;
                        exist.UnitPrice = product.UnitPrice;
                       

                        // we save the changes into the db
                        await _db.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View(product);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _db.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _db.Products.Where(x => x.Id == product.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        _db.Remove(exist);
                        await _db.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return View();
        }




    }



    
}
