using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Slider Slider { get; set; }
    }
}
