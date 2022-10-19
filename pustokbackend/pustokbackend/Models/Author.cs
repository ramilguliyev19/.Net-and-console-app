using System.Collections.Generic;

namespace pustokbackend.Models
{
    public class Author:BaseEntity
    {
        public List<Product> Products { get; set; }
        public string Fullname { get; set; }

    }
}

    