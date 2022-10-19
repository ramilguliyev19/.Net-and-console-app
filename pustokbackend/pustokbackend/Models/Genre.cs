using System.Collections.Generic;

namespace pustokbackend.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
