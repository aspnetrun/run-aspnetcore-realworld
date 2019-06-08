using AspnetRun.Web.ViewModels.Base;

namespace AspnetRun.Web.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public double Star { get; set; }
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
