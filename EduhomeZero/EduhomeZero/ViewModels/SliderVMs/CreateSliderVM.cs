using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EduhomeZero.ViewModels.SliderVMs
{
    public class CreateSliderVM
    {
        [Required, MaxLength(128)]
        public string Title { get; set; }
        [Required, MaxLength(128)]
        public string Description { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
