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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var slider = await _context.Sliders
                .Where(n => !n.IsDeleted).ToListAsync();

            return View(slider);
        }


        public async Task<IActionResult> Details(int id)
        {
            var slider = await _context.Sliders
                .Where(n => !n.IsDeleted && n.Id == id)
                .FirstOrDefaultAsync();

            if (slider is null)
            {
                return NotFound();
            }
            return View(slider);
        }


        public async Task<IActionResult> Update(int id)
        {
            var slider = await _context.Sliders
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (slider is null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, 
                                                string authorName,
                                                string bookName,
                                                string infoAboutBook,
                                                decimal price
                                                )
        {
            var slider = await _context.Sliders
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (slider is null || string.IsNullOrEmpty(authorName.Trim()))
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(bookName.Trim()) || string.IsNullOrEmpty(infoAboutBook.Trim()))
            {
                return NotFound();
            }
            if (price < 0)
            {
                return NotFound();
            }
            slider.Title1 = authorName.Trim();
            slider.Title2 = bookName.Trim();
            slider.Info = infoAboutBook.Trim();
            slider.Price = price;
            slider.UpdatedData = DateTime.Now;
            _context.Sliders.Update(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: nameof(Index), controllerName: nameof(Slider), routeValues: new { id });
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            
            if (await IsSliderExist(slider.Title1, slider.Title2, slider.Info, slider.Price) )
            {
                return Content("Something missing . " +
                               "\n  fill blanks totally.");
            }

            slider.CreatedData = DateTime.Now;
            slider.UpdatedData = DateTime.Now;

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "index", controllerName: "slider");
        
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (slider is null)
            {
                return NotFound();
            }

            return View(slider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Slider slider)
        {
            var dbslider = await _context.Sliders
                            .Where(n => !n.IsDeleted && n.Id == slider.Id)
                            .FirstOrDefaultAsync();

            if (dbslider is null)
            {
                return NotFound();
            }
            if (dbslider.Title1.ToLower() != slider.Title1.Trim().ToLower())
            {
                return Content("Can't delete");
            }

            dbslider.IsDeleted = true;
            _context.Sliders.Update(dbslider);
            await _context.SaveChangesAsync();

            return RedirectToAction(actionName: "index", controllerName: "slider");
        }

        public async Task<bool> IsSliderExist(string autorName,
                                                string bookName,
                                                string infoAboutBook,
                                                decimal price
                                              )
        {
            var isExist = await _context.Sliders
                .AnyAsync(n => n.Title1.ToLower() == autorName.Trim().ToLower() &&
                          n.Title2.ToLower() == bookName.Trim().ToLower() &&
                          n.Info.ToLower() == infoAboutBook.Trim().ToLower() &&
                          n.Price == price
                          );
            
            return isExist;
        }
    }
}
