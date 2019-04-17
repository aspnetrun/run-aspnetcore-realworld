using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetRun.Infrastructure.Persistence
{
    public class AspnetRunContext : DbContext
    {
        public AspnetRunContext(DbContextOptions<AspnetRunContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Brand>(ConfigureBrand);
            builder.Entity<Supplier>(ConfigureSupplier);
            builder.Entity<Category>(ConfigureCategory);
            builder.Entity<Product>(ConfigureProduct);

            builder.Entity<Customer>(ConfigureCustomer);

            builder.Entity<Order>(ConfigureOrder);
            builder.Entity<OrderDetail>(ConfigureOrderDetail);
            
            builder.Entity<ShoppingCart>(ConfigureShoppingCart);
            builder.Entity<ShoppingCartItem>(ConfigureShoppingCartItem);
            
            builder.Entity<User>(ConfigureUser);            
        }

        private void ConfigureBrand(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.BrandName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureSupplier(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.OwnsOne(s => s.Address);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.ProductName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(c => c.Address);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.OrderDate)
                .IsRequired();

            builder.OwnsOne(o => o.ShippingAddress);
        }

        private void ConfigureOrderDetail(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.OrderId)
                .IsRequired();                
        }
       
        private void ConfigureShoppingCart(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();       
        }

        private void ConfigureShoppingCartItem(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItem");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();
        }        

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("aspnetrun_type_hilo")
               .IsRequired();

            builder.OwnsOne(u => u.AdAccount);
        }
    }
}
