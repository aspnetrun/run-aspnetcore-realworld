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

                await SeedCustomers(aspnetrunContext);
                await SeedCategories(aspnetrunContext);
                await SeedProducts(aspnetrunContext);


                // TODO : here - seed database methods

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

        public static async Task SeedCustomers(AspnetRunContext context)
        {
            if (!context.Customers.Any())
                return;

            var customers = new List<Customer>()
            {
                new Customer { Id = 1, FirstName = "ALFKI", LastName = "Alfreds", BirthDate = new DateTime(1988, 5, 18), CompanyName = "Alfreds Futterkiste", Phone = "030-0074321", Title = "Sales Representative", Address = new Core.ValueObjects.Address{ AddressDesc = "Obere Str. 57", Region = "RMEA", Country = "Germany", City = "Berlin", PostalCode = "12209"} },
                new Customer { Id = 2, FirstName = "ANATR", LastName = "Trujillo", BirthDate = new DateTime(1988, 5, 18), CompanyName = "Ana Trujillo Emparedados y helados", Phone = "030-4729", Title = "Sales Representative", Address = new Core.ValueObjects.Address{ AddressDesc = "Avda. de la Constitución 2222", Region = "RMEA", Country = "Mexico", City = "México D.F.", PostalCode = "05021"} }                                
            };            

            context.Customers.AddRange(customers);
            await context.SaveChangesAsync();
        }

        public static async Task SeedCategories(AspnetRunContext context)
        {
            if (!context.Categories.Any())
                return;

            var catgories = new List<Category>()
            {                
                new Category() { Id = 1, CategoryName = "Phone", Description = "" },
                new Category() { Id = 2, CategoryName = "TV", Description = "" }
            };

            context.Categories.AddRange(catgories);
            await context.SaveChangesAsync();
        }

        public static async Task SeedProducts(AspnetRunContext context)
        {
            if (!context.Products.Any())
                return;

            var products = new List<Product>()
            {
                new Product() { Id = 1, ProductName = "IPhone", CategoryId = 1 , UnitPrice = 19.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false },
                new Product() { Id = 2, ProductName = "Samsung", CategoryId = 1 , UnitPrice = 33.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false },
                new Product() { Id = 3, ProductName = "LG TV", CategoryId = 2 , UnitPrice = 33.5M , UnitsInStock = 10, QuantityPerUnit = "2", UnitsOnOrder = 1, ReorderLevel = 1, Discontinued = false }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
        
    }
}
