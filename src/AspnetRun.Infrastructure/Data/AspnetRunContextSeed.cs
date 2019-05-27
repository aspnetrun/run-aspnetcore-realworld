using AspnetRun.Core.Entities;
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

                // categories - specifications - reviews - tags
                await SeedCategoriesAsync(aspnetrunContext);
                await SeedSpecificationsAsync(aspnetrunContext);
                await SeedReviewsAsync(aspnetrunContext);
                await SeedTagsAsync(aspnetrunContext);

                // products - related products - lists
                await SeedProductsAsync(aspnetrunContext);
                await SeedRelatedProductsAsync(aspnetrunContext);
                await SeedListsAsync(aspnetrunContext);

                // compares and wishlists
                await SeedComparesAsync(aspnetrunContext);
                await SeedWishlistsAsync(aspnetrunContext);

                // cart and cart items - order and order items
                await SeedCartAndItemsAsync(aspnetrunContext);
                await SeedOrderAndItemsAsync(aspnetrunContext);

                await SeedBlogsAsync(aspnetrunContext);                
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
                
        private static async Task SeedCategoriesAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Categories.Any())
                return;

            var categories = new List<Category>()
            {
                new Category() { Name = "Laptop"}, // 1
                new Category() { Name = "Drone"}, // 2
                new Category() { Name = "TV & Audio"}, // 3
                new Category() { Name = "Phone & Tablet"}, // 4
                new Category() { Name = "Camera & Printer"}, // 5
                new Category() { Name = "Games"}, // 6
                new Category() { Name = "Accessories"}, // 7
                new Category() { Name = "Watch"}, // 8
                new Category() { Name = "Home & Kitchen Appliances"} // 9
            };

            aspnetrunContext.Categories.AddRange(categories);
            await aspnetrunContext.SaveChangesAsync();
        }       

        private static async Task SeedSpecificationsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Specifications.Any())
                return;

            var specifications = new List<Specification>()
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
            };

            aspnetrunContext.Specifications.AddRange(specifications);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedReviewsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Reviews.Any())
                return;

            var reviews = new List<Review>()
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
            };

            aspnetrunContext.Reviews.AddRange(reviews);
            await aspnetrunContext.SaveChangesAsync();            
        }

        private static async Task SeedTagsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Tags.Any())
                return;

            var tags = new List<Tag>()
            {
                new Tag
                {
                    Name = "Electronic"
                },
                new Tag
                {
                    Name = "Smartphone"
                },
                new Tag
                {
                    Name = "Phone"
                },
                new Tag
                {
                    Name = "Charger"
                },
                new Tag
                {
                    Name = "Powerbank"
                }
            };

            aspnetrunContext.Tags.AddRange(tags);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedProductsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Products.Any())
                return;

            var products = new List<Product>
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
                    Category = aspnetrunContext.Categories.FirstOrDefault(c => c.Name == "Phone & Tablet"),
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Ornet Note 9",
                    Slug = "ornet-note",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-17.png",
                    UnitPrice = 285,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Sany Experia Z5",
                    Slug = "sany-experia",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-24.png",
                    UnitPrice = 360,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Flex P 3310",
                    Slug = "flex-p",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-19.png",
                    UnitPrice = 220,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 4,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Camera                
                new Product()
                {
                    Name = "Mony Handycam Z 105",
                    Slug = "mony-handycam-z",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    UnitPrice = 145,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Axor Digital Camera",
                    Slug = "axor-digital",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    UnitPrice = 199,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Silvex DSLR Camera T 32",
                    Slug = "silvex-camera",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-7.png",
                    UnitPrice = 580,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Necta Instant Camera",
                    Slug = "necta-instant",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-8.png",
                    UnitPrice = 320,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Printer
                new Product()
                {
                    Name = "Pranon Photo Printer Y 25",
                    Slug = "pranon-printer",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-11.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 5,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Game                
                new Product()
                {
                    Name = "Game Station X 22",
                    Slug = "game-station-x",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 6,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Game Stations PW 25",
                    Slug = "game-station-pw",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-13.png",
                    UnitPrice = 285,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 6,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Laptop      
                new Product()
                {
                    Name = "Zeon Zen 4 Pro",
                    Slug = "zeon-zen",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    UnitPrice = 295,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 1,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Drone                
                new Product()
                {
                    Name = "Aquet Drone D 420",
                    Slug = "aquet-drone",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    UnitPrice = 275,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 2,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Accessories
                new Product()
                {
                    Name = "Roxxe Headphone Z 75",
                    Slug = "roxxe-headphone-z",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    UnitPrice = 110,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 7,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Watch
                new Product()
                {
                    Name = "Mascut Smart Watch",
                    Slug = "mascut-smart",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-9.png",
                    UnitPrice = 365,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 8,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Z Bluetooth Headphone",
                    Slug = "z-bluetooth",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-10.png",
                    UnitPrice = 189,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 8,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // TV & Audio
                new Product()
                {
                    Name = "Roses Speaker Box",
                    Slug = "roses-speaker",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-12.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Nexo Andriod TV Box",
                    Slug = "nexo-andriod",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-16.png",
                    UnitPrice = 360,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Xonet Speaker P 9",
                    Slug = "xonet-speaker",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-18.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 3,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                // Home & Kitchen Appliances
                new Product()
                {
                    Name = "Zorex Coffe Maker",
                    Slug = "zorex-coffe",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-14.png",
                    UnitPrice = 210,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Jeilips Steam Iron K 2",
                    Slug = "jeilips-steam",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-15.png",
                    UnitPrice = 365,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Jackson Toster V 27",
                    Slug = "jackson-toster",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-20.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Mega Juice Maker",
                    Slug = "mega-juice",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-21.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Shine Microwave Oven",
                    Slug = "shine-microwave",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-22.png",
                    UnitPrice = 185,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                },
                new Product()
                {
                    Name = "Auto Rice Cooker",
                    Slug = "auto-rice",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-23.png",
                    UnitPrice = 130,
                    UnitsInStock = 10,
                    Star = 4.3,
                    CategoryId = 9,
                    Specifications = aspnetrunContext.Specifications.ToList(),
                    Reviews = aspnetrunContext.Reviews.ToList(),
                    Tags = aspnetrunContext.Tags.ToList()
                }
            };

            aspnetrunContext.Products.AddRange(products);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedRelatedProductsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Products.FirstOrDefault().RelatedProducts.Any())
                return;

            foreach (var product in aspnetrunContext.Products)
            {
                product.RelatedProducts.AddRange(aspnetrunContext.Products.TakeLast(5).ToList());
            }

            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedListsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Lists.Any())
                return;

            var lists = new List<List>()
            {
                new List
                {
                    Name = "FEATURED ITEMS",
                    Description = "",
                    ImageFile = "",
                    Products = aspnetrunContext.Products.Where(x => x.Id % 2 == 1).Take(5).ToList()
                },
                new List
                {
                    Name = "BEST SELLERS",
                    Description = "",
                    ImageFile = "",
                    Products = aspnetrunContext.Products.TakeLast(8).ToList()
                },
                new List
                {
                    Name = "BEST DEALS",
                    Description = "",
                    ImageFile = "",
                    Products = aspnetrunContext.Products.Where(p => p.Name.Length > 15).Take(5).ToList()
                },
                new List
                {
                    Name = "NEW ARRIVAL",
                    Description = "",
                    ImageFile = "",
                    Products = aspnetrunContext.Products.Where(x => x.Id % 2 != 1).Take(5).ToList()
                },
            };

            aspnetrunContext.Lists.AddRange(lists);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedWishlistsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Wishlists.Any())
                return;

            var wishlists = new List<Wishlist>()
            {
                new Wishlist
                {
                    UserName = "mehmetozkaya",
                    Products = aspnetrunContext.Products.Where(x => x.Id % 2 == 1).Take(4).ToList()
                }
            };

            aspnetrunContext.Wishlists.AddRange(wishlists);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedComparesAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Compares.Any())
                return;

            var compares = new List<Compare>()
            {
                new Compare
                {
                    UserName = "mehmetozkaya",
                    Products = aspnetrunContext.Products.Where(x => x.Id % 2 != 1).Take(3).ToList()
                }
            };

            aspnetrunContext.Compares.AddRange(compares);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedCartAndItemsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Carts.Any())
                return;

            var carts = new List<Cart>()
            {
                new Cart
                {
                    UserName = "mehmetozkaya",
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                        },
                        new CartItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new CartItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                            Quantity = 1,
                            Color = "Black",
                            UnitPrice = 185,
                            TotalPrice = 185
                        }
                    }
                }
            };

            aspnetrunContext.Carts.AddRange(carts);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedOrderAndItemsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Orders.Any())
                return;

            var address = new Address
            {
                AddressLine = "Gungoren",
                City = "Istanbul",
                Country = "Turkey",
                EmailAddress = "aspnetrun@outlook.com",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                CompanyName = "AspnetRun",
                PhoneNo = "05012222222",
                State = "027",
                ZipCode = "34056"
            };

            var orders = new List<Order>()
            {
                new Order
                {
                    UserName = "mehmetozkaya",
                    BillingAddress = address,
                    ShippingAddress = address,
                    PaymentMethod = PaymentMethod.Cash,
                    Status = OrderStatus.Progress,
                    GrandTotal = 347,
                    Items = new List<OrderItem>
                    {
                       new OrderItem
                       {
                           Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "uPhone X"),
                            Quantity = 2,
                            Color = "Black",
                            UnitPrice = 295,
                            TotalPrice = 590
                       },
                        new OrderItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Game Station X 22"),
                            Quantity = 1,
                            Color = "Red",
                            UnitPrice = 295,
                            TotalPrice = 295
                        },
                        new OrderItem
                        {
                            Product = aspnetrunContext.Products.FirstOrDefault(p => p.Name == "Jackson Toster V 27"),
                            Quantity = 1,
                            Color = "Black",
                            UnitPrice = 185,
                            TotalPrice = 185
                        }
                    }
                }
            };

            aspnetrunContext.Orders.AddRange(orders);
            await aspnetrunContext.SaveChangesAsync();
        }

        private static async Task SeedBlogsAsync(AspnetRunContext aspnetrunContext)
        {
            if (aspnetrunContext.Blogs.Any())
                return;

            var blogs = new List<Blog>()
            {
                new Blog
                {
                    Name = "Latest Drone for taking sky view image and 4K video",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-10.jpg"
                },
                new Blog
                {
                    Name = "Zeon Z 5 Pro Laptop makes your life easy and simple",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                },
                new Blog
                {
                    Name = "Latest Play Station for plying exclusive games",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-11.jpg"
                },
                new Blog
                {
                    Name = "The most attractive Smart watch comming in this February",
                    Description = "enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magniolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dorem ipsum quia dolor sit met, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem",
                    ImageFile = "blog-12.jpg"
                }
            };

            aspnetrunContext.Blogs.AddRange(blogs);
            await aspnetrunContext.SaveChangesAsync();
        }        
    }
}
