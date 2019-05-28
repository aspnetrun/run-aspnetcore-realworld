using System;
using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        public DbSet<ProductWishlist> ProductWishlists { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>(ConfigureBlog);
            builder.Entity<Cart>(ConfigureCart);
            builder.Entity<CartItem>(ConfigureCartItem);
            builder.Entity<Category>(ConfigureCategory);
            builder.Entity<Compare>(ConfigureCompare);
            builder.Entity<Contact>(ConfigureContact);
            builder.Entity<List>(ConfigureList);
            builder.Entity<Order>(ConfigureOrder);
            builder.Entity<OrderItem>(ConfigureOrderItem);
            builder.Entity<Product>(ConfigureProduct);
            builder.Entity<Review>(ConfigureReview);
            builder.Entity<Specification>(ConfigureSpecification);
            builder.Entity<Tag>(ConfigureTag);            

            builder.Entity<ProductWishlist>(ConfigureProductWishlist);
        }

        private void ConfigureBlog(EntityTypeBuilder<Blog> builder)
        {
            
        }

        private void ConfigureCart(EntityTypeBuilder<Cart> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Cart.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureCartItem(EntityTypeBuilder<CartItem> builder)
        {

        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCompare(EntityTypeBuilder<Compare> builder)
        {

        }

        private void ConfigureContact(EntityTypeBuilder<Contact> builder)
        {

        }
        private void ConfigureList(EntityTypeBuilder<List> builder)
        {

        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Order.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            // NOTE : This Owns methods provide to accept value object like Address
            builder.OwnsOne(o => o.ShippingAddress);
            builder.OwnsOne(o => o.BillingAddress);
        }

        private void ConfigureOrderItem(EntityTypeBuilder<OrderItem> builder)
        {

        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {

        }

        private void ConfigureSpecification(EntityTypeBuilder<Specification> builder)
        {

        }

        private void ConfigureTag(EntityTypeBuilder<Tag> builder)
        {

        }

        private void ConfigureProductWishlist(EntityTypeBuilder<ProductWishlist> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.WishlistId });
        }
    }
}
