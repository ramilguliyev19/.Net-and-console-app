using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace pustokbackend.Areas.Manage.Controllers
{
    public class FeatureController : Controller
    {
        public class Feature : Controller
        {
            private readonly AppDbContext _context;

            public Feature(AppDbContext context)
            {
                _context = context;
            }
            // GET
            public IActionResult Index()
            {
                List<pustokbackend.Models.Feature> features = _context.Features.Where(f => !f.IsDeleted).ToList();
                return View(features);
            }

            public IActionResult Details(int id)
            {
                pustokbackend.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
                return View(feature);
            }

            [HttpGet]
            public IActionResult Update(int id)
            {
                pustokbackend.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
                return View(feature);
            }

            [HttpPost]
            public IActionResult Update(int id, string title, string subtitle, string iconUrl)
            {
                pustokbackend.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
                feature.Title1 = title;
                feature.IconUrl = iconUrl;
                feature.Title2 = subtitle;
                _context.Features.Update(feature);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult Delete(int id)
            {
                pustokbackend.Models.Feature feature = _context.Features.Where(f => f.Id == id).FirstOrDefault();
                feature.IsDeleted = true;
                _context.Features.Update(feature);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(pustokbackend.Models.Feature feature)
            {
                _context.Features.Add(feature);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
