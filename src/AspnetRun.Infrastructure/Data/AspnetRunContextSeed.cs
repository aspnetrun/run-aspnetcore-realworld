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
                }                
            };
        }
    }
}
