using System;
using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetRun.Infrastructure.Data
{
    public class AspnetRunContext : IdentityDbContext<IdentityUser>
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

        // aggregate
        public DbSet<ProductWishlist> ProductWishlists { get; set; }
        public DbSet<ProductCompare> ProductCompares { get; set; }
        public DbSet<ProductList> ProductLists { get; set; }
        public DbSet<ProductRelatedProduct> ProductRelatedProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            SetTableNamesAsSingle(builder);

            //builder.Entity<Blog>(ConfigureBlog);
            //builder.Entity<Cart>(ConfigureCart);
            //builder.Entity<CartItem>(ConfigureCartItem);
            //builder.Entity<Category>(ConfigureCategory);
            //builder.Entity<Compare>(ConfigureCompare);
            //builder.Entity<Contact>(ConfigureContact);
            //builder.Entity<List>(ConfigureList);
            builder.Entity<Order>(ConfigureOrder);
            //builder.Entity<OrderItem>(ConfigureOrderItem);
            builder.Entity<Product>(ConfigureProduct);
            //builder.Entity<Review>(ConfigureReview);
            //builder.Entity<Specification>(ConfigureSpecification);
            //builder.Entity<Tag>(ConfigureTag);

            builder.Entity<ProductWishlist>(ConfigureProductWishlist);
            builder.Entity<ProductCompare>(ConfigureProductCompare);
            builder.Entity<ProductList>(ConfigureProductList);
            builder.Entity<ProductRelatedProduct>(ConfigureProductRelatedProduct);
        }

        private static void SetTableNamesAsSingle(ModelBuilder builder)
        {
            // Use the entity name instead of the Context.DbSet<T> name
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            // NOTE : This Owns methods provide to accept value object like Address
            builder.OwnsOne(o => o.ShippingAddress);
            builder.OwnsOne(o => o.BillingAddress);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            // check for conventions - http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx


            // add self reference table configuration
            // https://github.com/aspnet/EntityFrameworkCore/issues/10698 
            // https://stackoverflow.com/questions/27613117/introducing-foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths-s

            builder
                .HasMany(p => p.ProductRelatedProducts)
                .WithOne(pr => pr.Product)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        // N&N RELATIONSHIP CONFIGRATION - NOTE : We have to set keys for n-n tables otherwise EF.Core gives primary key error
        private void ConfigureProductWishlist(EntityTypeBuilder<ProductWishlist> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.WishlistId });
        }

        private void ConfigureProductCompare(EntityTypeBuilder<ProductCompare> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.CompareId });
        }

        private void ConfigureProductList(EntityTypeBuilder<ProductList> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.ListId });
        }

        private void ConfigureProductRelatedProduct(EntityTypeBuilder<ProductRelatedProduct> builder)
        {
            builder.HasKey(pw => new { pw.ProductId, pw.RelatedProductId });
        }
    }
}
