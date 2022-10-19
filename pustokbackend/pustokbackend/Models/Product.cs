namespace pustokbackend.Models
{
    public class Product : BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Desciption { get; set; }
        public string Info { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }



    }
}


