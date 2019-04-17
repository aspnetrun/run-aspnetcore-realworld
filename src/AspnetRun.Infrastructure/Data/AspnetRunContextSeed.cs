using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Persistence
{
    public class AspnetRunContextSeed
    {
        public static async Task SeedAsync(AspnetRunContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                // aspnetrunContext.Database.Migrate();
                // aspnetrunContext.Database.EnsureCreated();

                if (aspnetrunContext.Categories.Any())
                    return; // Db has been seeded

                await SeedBrands(aspnetrunContext);
                await SeedSuppliers(aspnetrunContext);
                await SeedCategories(aspnetrunContext);
                await SeedProducts(aspnetrunContext);

                await SeedCustomers(aspnetrunContext);

                await SeedOrders(aspnetrunContext);
                await SeedOrderDetails(aspnetrunContext);

                await SeedShoppingCarts(aspnetrunContext);
                await SeedShoppingCartItems(aspnetrunContext);
                
                await SeedUsers(aspnetrunContext);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AspnetRunContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(aspnetrunContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task SeedBrands(AspnetRunContext context)
        {
            if (context.Brands.Any())
                return;

            var brands = new List<Brand>()
            {
                new Brand { Id = 1, BrandName = "Apple", Description = "" },
                new Brand { Id = 2, BrandName = "Huwaei", Description = "" },
                new Brand { Id = 3, BrandName = "LG", Description = "" },
                new Brand { Id = 4, BrandName = "Samsung", Description = "" }
            };

            context.Brands.AddRange(brands);
            await context.SaveChangesAsync();
        }

        private static async Task SeedSuppliers(AspnetRunContext context)
        {
            if (context.Suppliers.Any())
                return;

            var suppliers = new List<Supplier>()
            {
                new Supplier() { Id = 1, CompanyName = "Exotic Liquids", ContactName = "Charlotte Cooper", ContactTitle = "Purchasing Manager", Fax = "", Phone = "(171) 555-2222", HomePage = "", Address = new Core.ValueObjects.Address{ AddressDesc = "49 Gilbert St.", City = "London", PostalCode = "EC1 4SD" } },
                new Supplier() { Id = 2, CompanyName = "Grandma Kelly's Homestead", ContactName = "Regina Murphy", ContactTitle = "Sales Representative", Fax = "(313) 555-3349", Phone = "(313) 555-5735", HomePage = "", Address = new Core.ValueObjects.Address{ AddressDesc = "707 Oxford Rd.", City = "Ann Arbor", Region = "MI", PostalCode = "48104" } },
                new Supplier() { Id = 3, CompanyName = "New Orleans Cajun Delights", ContactName = "Shelley Burke", ContactTitle = "Order Administrator", Fax = "", Phone = "(100) 555-4822", HomePage = "#CAJUN.HTM#", Address = new Core.ValueObjects.Address {AddressDesc = "P.O. Box 78934", City = "New Orleans", Region = "LA", PostalCode = "70117" } }
            };

            context.Suppliers.AddRange(suppliers);
            await context.SaveChangesAsync();
        }
        
        public static async Task SeedCategories(AspnetRunContext context)
        {
            if (context.Categories.Any())
                return;

            var catgories = new List<Category>()
            {                
                new Category() { Id = 1, CategoryName = "Phone", Description = "" },
                new Category() { Id = 2, CategoryName = "TV", Description = "" },
                new Category() { Id = 3, CategoryName = "Beverages", Description = "" },
                new Category() { Id = 4, CategoryName = "Condiments", Description = "" },
                new Category() { Id = 5, CategoryName = "Confections", Description = "" }
            };

            context.Categories.AddRange(catgories);
            await context.SaveChangesAsync();
        }

        public static async Task SeedProducts(AspnetRunContext context)
        {
            if (context.Products.Any())
                return;

            var products = new List<Product>()
            {
                new Product() { Id = 1, ProductName = "IPhone", SupplierId = 1, CategoryId = 1, BrandId = 1, Description = "IPhone X Black", PictureUri = "http://catalogbaseurltobereplaced/images/products/1.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
                new Product() { Id = 2, ProductName = "Samsung", SupplierId = 2, CategoryId = 2, BrandId = 2, Description = "Galaxy 10 Silver", PictureUri = "http://catalogbaseurltobereplaced/images/products/2.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
                new Product() { Id = 3, ProductName = "LG TV", SupplierId = 3, CategoryId = 3, BrandId = 3, Description = "View X", PictureUri = "http://catalogbaseurltobereplaced/images/products/3.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
                new Product() { Id = 4, ProductName = "Ikura", SupplierId = 2, CategoryId = 1, BrandId = 1, Description = "Ikura", PictureUri = "http://catalogbaseurltobereplaced/images/products/4.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
                new Product() { Id = 5, ProductName = "Queso", SupplierId = 1, CategoryId = 2, BrandId = 3, Description = "Queso", PictureUri = "http://catalogbaseurltobereplaced/images/products/5.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
                new Product() { Id = 6, ProductName = "Schoggi", SupplierId = 3, CategoryId = 3, BrandId = 2, Description = "Schoggi", PictureUri = "http://catalogbaseurltobereplaced/images/products/6.png", QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }

        public static async Task SeedCustomers(AspnetRunContext context)
        {
            if (context.Customers.Any())
                return;

            var customers = new List<Customer>()
            {
                new Customer { Id = 1, FirstName = "ALFKI", LastName = "Alfreds", BirthDate = new DateTime(1988, 5, 18), CompanyName = "Alfreds Futterkiste", Phone = "030-0074321", Title = "Sales Representative", Address = new Core.ValueObjects.Address{ AddressDesc = "Obere Str. 57", Region = "RMEA", Country = "Germany", City = "Berlin", PostalCode = "12209"} },
                new Customer { Id = 2, FirstName = "ANATR", LastName = "Trujillo", BirthDate = new DateTime(1988, 5, 18), CompanyName = "Ana Trujillo Emparedados y helados", Phone = "030-4729", Title = "Sales Representative", Address = new Core.ValueObjects.Address{ AddressDesc = "Avda. de la Constitución 2222", Region = "RMEA", Country = "Mexico", City = "México D.F.", PostalCode = "05021"} }
            };

            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }

        public static async Task SeedOrders(AspnetRunContext context)
        {
            if (context.Orders.Any())
                return;

            var orders = new List<Order>()
            {
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-5), ShippedDate = DateTime.Now.AddDays(-2), Freight = 32.38m, ShipVia = 0, ShippingAddress = new Core.ValueObjects.Address { AddressDesc = "59 rue de l'Abbaye", City = "Reims", Country = "France", Region = "", PostalCode = "51100" } },
                new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-5), ShippedDate = DateTime.Now.AddDays(-2), Freight = 32.38m, ShipVia = 0, ShippingAddress = new Core.ValueObjects.Address { AddressDesc = "59 rue de l'Abbaye", City = "Reims", Country = "France", Region = "", PostalCode = "51100" } },
                new Order { Id = 3, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-5), ShippedDate = DateTime.Now.AddDays(-2), Freight = 32.38m, ShipVia = 0, ShippingAddress = new Core.ValueObjects.Address { AddressDesc = "59 rue de l'Abbaye", City = "Reims", Country = "France", Region = "", PostalCode = "51100" } }
            };

            context.Orders.AddRange(orders);
            await context.SaveChangesAsync();
        }

        public static async Task SeedOrderDetails(AspnetRunContext context)
        {
            if (context.OrderDetails.Any())
                return;

            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new OrderDetail { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, Discount = 0, UnitPrice = 1.4M },
                new OrderDetail { Id = 3, OrderId = 1, ProductId = 3, Quantity = 2, Discount = 0, UnitPrice = 1.4M },
                new OrderDetail { Id = 4, OrderId = 2, ProductId = 4, Quantity = 2, Discount = 0, UnitPrice = 1.4M },
                new OrderDetail { Id = 5, OrderId = 2, ProductId = 5, Quantity = 2, Discount = 0, UnitPrice = 1.4M },
                new OrderDetail { Id = 6, OrderId = 3, ProductId = 6, Quantity = 2, Discount = 0, UnitPrice = 1.4M }
            };

            context.OrderDetails.AddRange(orderDetails);
            await context.SaveChangesAsync();
        }

        public static async Task SeedShoppingCarts(AspnetRunContext context)
        {
            if (context.ShoppingCarts.Any())
                return;

            var shoppingCarts = new List<ShoppingCart>()
            {
                new ShoppingCart { Id = 1, UserId = 1 },
                new ShoppingCart { Id = 2, UserId = 2 },
                new ShoppingCart { Id = 3, UserId = 3 }
            };

            context.ShoppingCarts.AddRange(shoppingCarts);
            await context.SaveChangesAsync();
        }

        public static async Task SeedShoppingCartItems(AspnetRunContext context)
        {
            if (context.ShoppingCartItems.Any())
                return;

            var shoppingCartItems = new List<ShoppingCartItem>()
            {
                new ShoppingCartItem { Id = 1, ShoppingCartId = 1, ProductId = 1, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new ShoppingCartItem { Id = 2, ShoppingCartId = 1, ProductId = 2, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new ShoppingCartItem { Id = 3, ShoppingCartId = 2, ProductId = 1, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new ShoppingCartItem { Id = 4, ShoppingCartId = 2, ProductId = 3, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new ShoppingCartItem { Id = 5, ShoppingCartId = 2, ProductId = 4, Quantity = 4, Discount = 0, UnitPrice = 1.4M },
                new ShoppingCartItem { Id = 6, ShoppingCartId = 3, ProductId = 5, Quantity = 4, Discount = 0, UnitPrice = 1.4M }
            };

            context.ShoppingCartItems.AddRange(shoppingCartItems);
            await context.SaveChangesAsync();
        }

        public static async Task SeedUsers(AspnetRunContext context)
        {
            if (context.Users.Any())
                return;

            var users = new List<User>()
            {
                new User { Id = 1, IdentityGuid = "testuser@user.com", AdAccount = Core.ValueObjects.AdAccount.For("TCRM32LAB\\Admin") },
                new User { Id = 2, IdentityGuid = "testuser2@user.com", AdAccount = Core.ValueObjects.AdAccount.For("TCRM32LAB\\ezozkme") },
                new User { Id = 3, IdentityGuid = "testuser3@user.com", AdAccount = Core.ValueObjects.AdAccount.For("TCRM32LAB\\emehozk") }
            };

            context.Users.AddRange(users);
            await context.SaveChangesAsync();
        }

    }
}
