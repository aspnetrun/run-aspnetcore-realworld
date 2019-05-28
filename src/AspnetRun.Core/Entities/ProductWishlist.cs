namespace AspnetRun.Core.Entities
{
    public class ProductWishlist
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
