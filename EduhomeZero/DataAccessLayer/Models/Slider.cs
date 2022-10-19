using Core.Entity;
using DataAccessLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Slider : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
