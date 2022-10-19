using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustokbackend;
using pustokbackend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace pustokbackend.Areas.Admin.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _context.Products
                .Where(n => !n.IsDeleted)
                .Include(n => n.Author)
                .Include(n => n.Genre)
                .ToListAsync();

            return View(product);
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Where(n => !n.IsDeleted && n.Id == id)
                .Include(n => n.Author)
                .Include(n => n.Genre)
                .FirstOrDefaultAsync();

            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }


        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .Include(n => n.Author)
                            .Include(n => n.Genre)
                            .FirstOrDefaultAsync();

            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, 
                                                string autorname,
                                                string genre,
                                                string book,
                                                decimal salePrice,
                                                decimal costPrice,
                                                decimal discountedPrice,
                                                string image
                                                )
        {
            var product = await _context.Products
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .Include(n => n.Author)
                            .Include(n => n.Genre)
                            .FirstOrDefaultAsync();

            if (product is null || string.IsNullOrEmpty(autorname.Trim()))
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(genre.Trim()) || string.IsNullOrEmpty(book.Trim()))
            {
                return NotFound();
            }
            if (salePrice < 0 || costPrice < 0 || discountedPrice < 0)
            {
                return NotFound();
            }
            product.Author.Fullname = autorname.Trim();
            product.Genre.Name = genre.Trim();
            product.Name = book.Trim();
            product.SalePrice = salePrice;
            product.CostPrice= costPrice;
            product.DiscountPrice = discountedPrice;
            product.Desciption = image.Trim();

            product.UpdatedData = DateTime.Now;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: nameof(Index), controllerName: nameof(Product), routeValues: new { id });
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {

          
           

            product.CreatedData = DateTime.Now;
            product.UpdatedData = DateTime.Now;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "index", controllerName: "product");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            var dbproduct = await _context.Products
                            .Where(n => !n.IsDeleted && n.Id == product.Id)
                            .FirstOrDefaultAsync();

            if (dbproduct is null)
            {
                return NotFound();
            }
            if (dbproduct.Name.ToLower() != product.Name.Trim().ToLower())
            {
                return Content("Cannot delete");
            }

            dbproduct.IsDeleted = true;
            _context.Products.Update(dbproduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(actionName: "index", controllerName: "product");
        }

    
    }
}
