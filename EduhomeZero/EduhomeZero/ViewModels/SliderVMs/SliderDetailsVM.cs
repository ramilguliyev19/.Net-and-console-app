﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EduhomeZero.ViewModels.SliderVMs
{
    public class SliderDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
