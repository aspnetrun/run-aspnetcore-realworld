namespace AspnetRun.Core.Entities
{
    public class ProductRelatedProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int RelatedProductId { get; set; }
        public Product RelatedProduct { get; set; }
    }
}
