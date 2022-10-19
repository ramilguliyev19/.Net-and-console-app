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
    public class PromotionController : Controller
    {
        private readonly AppDbContext _context;
        public PromotionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var promotion = await _context.Promotions
                .Where(n => !n.IsDeleted).ToListAsync();

            return View(promotion);
        }


        public async Task<IActionResult> Details(int id)
        {
            var promotion = await _context.Promotions
                .Where(n => !n.IsDeleted && n.Id == id)
                .FirstOrDefaultAsync();

            if (promotion is null)
            {
                return NotFound();
            }
            return View(promotion);
        }


        public async Task<IActionResult> Update(int id)
        {
            var promotion = await _context.Promotions
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (promotion is null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,
                                                string redirectUrl,
                                                string redirecrText
                                                )
        {
            var promotion = await _context.Promotions
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (promotion is null || string.IsNullOrEmpty(redirecrText.Trim()))
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(redirectUrl.Trim()))
            {
                return NotFound();
            }

            promotion.RedirectUrl = redirectUrl.Trim();
            promotion.RedirectText = redirecrText.Trim();

            promotion.UpdatedData = DateTime.Now;
            _context.Promotions.Update(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: nameof(Index), controllerName: nameof(Promotion), routeValues: new { id });
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Promotion promotion)
        {

           

            promotion.CreatedData = DateTime.Now;
            promotion.UpdatedData = DateTime.Now;

            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(actionName: "index", controllerName: "promotion");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var promotion = await _context.Promotions
                            .Where(n => !n.IsDeleted && n.Id == id)
                            .FirstOrDefaultAsync();

            if (promotion is null)
            {
                return NotFound();
            }

            return View(promotion);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Promotion promotion)
        {
            var dbpromotion = await _context.Promotions
                            .Where(n => !n.IsDeleted && n.Id == promotion.Id)
                            .FirstOrDefaultAsync();

            if (dbpromotion is null)
            {
                return NotFound();
            }
            if (dbpromotion.RedirectUrl.ToLower() != promotion.RedirectUrl.Trim().ToLower())
            {
                return Content("Cannot delete");
            }

            dbpromotion.IsDeleted = true;
            _context.Promotions.Update(dbpromotion);
            await _context.SaveChangesAsync();

            return RedirectToAction(actionName: "index", controllerName: "promotion");
        }

    
    }
}
