using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace pustokbackend.Models
{
    public class Slider :BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public int Order { get; set; }
     
    }
}
