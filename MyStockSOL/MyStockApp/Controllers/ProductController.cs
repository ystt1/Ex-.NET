using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStockApp.Models;

namespace MyStockApp.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly MyStockDbContext _context;

        public ProductController(MyStockDbContext context)
        {
            _context = context;
        }
        // Show all product
        public ActionResult Index()
        {
            var model=_context.Products.ToList();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
                return NotFound();
            var product = _context.Products.FirstOrDefault(m => m.ProductId == id);
            if(product == null)
                return NotFound();
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
           if(ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Product product)
        {
            if (id != product.ProductId)
                return NotFound();
            if(ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
