using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pustokbackend.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace pustokbackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Features = await _context.Features.ToListAsync(),
                Promotions = await _context.Promotions.ToListAsync(),
                SecondPromotions = await _context.SecondPromotions.ToListAsync(),

                FeaturedProducts = await _context.Products
                .Where(n => n.IsFeatured)
                .Include(n => n.Author)
                .Take(10).ToListAsync(),

                NewProducts = await _context.Products
                .Where(n => n.IsNew)
                .Include(n => n.Author)
                .Take(10).ToListAsync(),

                DiscountedProducts = await _context.Products
                .Where(n => n.DiscountPrice > 0)
                .Include(n => n.Author)
                .Take(10).ToListAsync()
            };

            return View(homeViewModel);
        }
    }
}