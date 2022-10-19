using Microsoft.AspNetCore.Http;

namespace EduhomeZero.ViewModels.SliderVMs
{
    public class UpdateSliderVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
