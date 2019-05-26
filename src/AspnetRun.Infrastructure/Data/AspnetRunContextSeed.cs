using AspnetRun.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Data
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

                if (!aspnetrunContext.Categories.Any())
                {
                    aspnetrunContext.Categories.AddRange(GetPreconfiguredCategories());
                    await aspnetrunContext.SaveChangesAsync();
                }

                if (!aspnetrunContext.Products.Any())
                {
                    aspnetrunContext.Products.AddRange(GetPreconfiguredProducts());
                    await aspnetrunContext.SaveChangesAsync();
                }
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

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {                
                new Category() { Name = "Laptop"},
                new Category() { Name = "Drone"},
                new Category() { Name = "TV & Audio"},
                new Category() { Name = "Phone & Tablet"},
                new Category() { Name = "Camera & Printer"},
                new Category() { Name = "Games"},
                new Category() { Name = "Accessories"}
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            // TODO : you are here -> seed db as normal db
            // note - list table for -> // Featured Items, Best Sellers sections etc..
            return new List<Product>()
            {
                // Phone
                new Product()
                {
                    Name = "uPhone X",
                    Slug = "uphone-x",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = new List<Specification>
                    {
                        new Specification
                        {
                            Name = "Full HD Camcorder",
                            Description = "Full HD Camcorder"
                        },
                        new Specification
                        {
                            Name = "Dual Video Recording",
                            Description = "Dual Video Recording"
                        },
                        new Specification
                        {
                            Name = "X type battery operation",
                            Description = "X type battery operation"
                        },
                        new Specification
                        {
                            Name = "Full HD Camcorder",
                            Description = "Full HD Camcorder"
                        },
                        new Specification
                        {
                            Name = "Dual Video Recording",
                            Description = "Dual Video Recording"
                        },
                        new Specification
                        {
                            Name = "X type battery operation",
                            Description = "X type battery operation"
                        }
                    },
                    Reviews = new List<Review>
                    {
                        new Review
                        {
                            Name = "Cristopher Lee",
                            EMail = "cristopher@lee.com",
                            Star = 4.3,
                            Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                        },
                        new Review
                        {
                            Name = "Nirob Khan",
                            EMail = "nirob@lee.com",
                            Star = 4.3,
                            Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                        },
                        new Review
                        {
                            Name = "MD.ZENAUL ISLAM",
                            EMail = "zenaul@lee.com",
                            Star = 4.3,
                            Comment = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia res eos qui ratione voluptatem sequi Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci veli"
                        }
                    }                 
                },

                new Product() { Name = "GL G6", CategoryId = 4 , UnitPrice = 295 , UnitsInStock = 10 },
                new Product() { Name = "MSVII Case", CategoryId = 4 , UnitPrice = 295 , UnitsInStock = 10 },

                // Camera
                new Product() { Name = "Mony Handycam Z 105", CategoryId = 5 , UnitPrice = 145 , UnitsInStock = 10 },
                new Product() { Name = "Axor Digital Camera", CategoryId = 5 , UnitPrice = 265 , UnitsInStock = 10 },
                new Product() { Name = "Silvex DSLR Camera T 32", CategoryId = 5 , UnitPrice = 580 , UnitsInStock = 10 },

                // Game
                new Product() { Name = "Game Station X 22", CategoryId = 6 , UnitPrice = 295 , UnitsInStock = 10 },

                // Laptop
                new Product() { Name = "Zeon Zen 4 Pro", CategoryId = 1 , UnitPrice = 295 , UnitsInStock = 10 },

                // Drone
                new Product() { Name = "Aquet Drone D 420", CategoryId = 2 , UnitPrice = 275 , UnitsInStock = 10 },

                // Accessories
                new Product() { Name = "Roxxe Headphone Z 75", CategoryId = 7 , UnitPrice = 110 , UnitsInStock = 10 },


                new Product() { Name = "Zeon Zen 4 Pro", CategoryId = 1 , UnitPrice = 295 , UnitsInStock = 10 },
                new Product() { Name = "Samsung", CategoryId = 1 , UnitPrice = 33.5M , UnitsInStock = 10 },
                new Product() { Name = "LG TV", CategoryId = 2 , UnitPrice = 33.5M , UnitsInStock = 10 }
            };
        }
    }
}
