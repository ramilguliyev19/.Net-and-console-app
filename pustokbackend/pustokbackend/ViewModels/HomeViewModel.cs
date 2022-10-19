using pustokbackend.Models;
using System.Collections.Generic;

namespace pustokbackend.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<SecondPromotion> SecondPromotions { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> NewProducts { get; set; }
        public List<Product> DiscountedProducts { get; set; }
        public List<Genre> Genres { get; set; }


    }
}
