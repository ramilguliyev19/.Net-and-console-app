using BusinessLayer.Services;
using Common.Extension;
using DataAccessLayer.Models;
using EduhomeZero.ViewModels.SliderVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduhomeZero.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _environment;
        private readonly IImageService _imageService;

        public SliderController(ISliderService sliderService, IWebHostEnvironment environment, IImageService imageService)
        {
            _sliderService = sliderService;
            _environment = environment;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            List<SliderDetailsVM> sliderDetails = new List<SliderDetailsVM>();

            try
            {
                List<Slider> sliders = await _sliderService.GetAll();

                foreach (Slider slider in sliders)
                {
                    sliderDetails.Add(MapSliderDetails(slider));
                }
            }
            catch (Exception ex)
            {
                return Json(new {
                    status = 404,
                    message = ex.Message
                });
            }

            return View(sliderDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderVM createSlider)
        {
            if (!ModelState.IsValid)
            {
                return View(createSlider);
            }

            if(createSlider.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "File cannot be null!");
                return View(createSlider);
            }

            if(!createSlider.ImageFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be an image!");
                return View(createSlider);
            }

            float fileSize = ((float)createSlider.ImageFile.Length) / 1024 / 1024;

            float allowedFileSize = 3;

            if(fileSize > allowedFileSize)
            {
                ModelState.AddModelError("ImageFile", $"Size of image must be under {allowedFileSize}MB!");
                return View(createSlider);
            }

            string fileName = await createSlider.ImageFile.CreateFile(_environment.WebRootPath, "images");

            Image image = new Image();
            image.Name = fileName;

            try
            {
                await _imageService.Create(image);
            }
            catch (Exception)
            {
                ModelState.AddModelError("ImageFile", "Something went wrong");
                return View(createSlider);
            }

            Slider slider = new Slider();
            slider.Title = createSlider.Title;
            slider.Description = createSlider.Description;
            slider.ImageId = image.Id;

            try
            {
                await _sliderService.Create(slider);
                return RedirectToAction(controllerName: nameof(Slider), actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            UpdateSliderVM updateSlider = new UpdateSliderVM();

            try
            {
                Slider slider = await _sliderService.Get(id);
                updateSlider.Title = slider.Title;
                updateSlider.Description = slider.Description;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 404,
                    message = ex.Message
                });
            }

            return View(updateSlider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, UpdateSliderVM updateSlider)
        {
            try
            {
                Slider slider = await _sliderService.Get(id);
                slider.Title = updateSlider.Title;
                slider.Description = updateSlider.Description;

                //if(!(updateSlider.ImageFile is null))
                //{
                //    string fileName = await updateSlider.ImageFile.CreateFile(_environment.WebRootPath, "images");

                //    slider.Image.Name = fileName;
                //}

                await _sliderService.Update(slider);
                return RedirectToAction(controllerName: nameof(Slider), actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 404,
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sliderService.Delete(id);
                return RedirectToAction(controllerName: nameof(Slider), actionName: nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = 405,
                    message = ex.Message
                });
            }
        }

        public SliderDetailsVM MapSliderDetails(Slider slider)
        {
            SliderDetailsVM sliderDetails = new SliderDetailsVM();

            sliderDetails.Id = slider.Id;
            sliderDetails.Title = slider.Title;
            sliderDetails.Description = slider.Description;
            //sliderDetails.ImageUrl = slider.Image.Name;

            return sliderDetails;
        }
    }
}
