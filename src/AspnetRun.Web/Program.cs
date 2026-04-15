using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Services;
using AspnetRun.Core.Configuration;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Logging;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Repository.Base;
using AspnetRun.Web.HealthChecks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure Cookie Policy
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Configure AspnetRun Services
ConfigureAspnetRunServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var aspnetRunContext = services.GetRequiredService<AspnetRunContext>();
        AspnetRunContextSeed.SeedAsync(aspnetRunContext, loggerFactory).Wait();
    }
    catch (Exception exception)
    {
        var logger = loggerFactory.CreateLogger("AspnetRun.Web.Program");
        logger.LogError(exception, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

static void ConfigureAspnetRunServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
{
    // Add Core Layer
    services.Configure<AspnetRunSettings>(configuration);

    // Add Infrastructure Layer
    ConfigureDatabases(services, configuration);
    ConfigureIdentity(services);

    services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<ICartRepository, CartRepository>();
    services.AddScoped<IWishlistRepository, WishlistRepository>();
    services.AddScoped<ICompareRepository, CompareRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();

    // Add Application Layer
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ICartService, CartService>();
    services.AddScoped<IWishlistService, WishListService>();
    services.AddScoped<ICompareService, CompareService>();
    services.AddScoped<IOrderService, OrderService>();

    // Add Web Layer
    services.AddAutoMapper(typeof(Program)); // Add AutoMapper
    services.AddScoped<IIndexPageService, IndexPageService>();
    services.AddScoped<IProductPageService, ProductPageService>();
    services.AddScoped<ICategoryPageService, CategoryPageService>();
    services.AddScoped<ICartComponentService, CartComponentService>();
    services.AddScoped<IWishlistPageService, WishlistPageService>();
    services.AddScoped<IComparePageService, ComparePageService>();
    services.AddScoped<ICheckOutPageService, CheckOutPageService>();

    // Add Miscellaneous
    services.AddHttpContextAccessor();
    services.AddHealthChecks()
        .AddCheck<IndexPageHealthCheck>("home_page_health_check");
}

static void ConfigureDatabases(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
{
    // use in-memory database
    services.AddDbContext<AspnetRunContext>(c =>
        c.UseInMemoryDatabase("AspnetRunConnection"));

    //// use real database
    //services.AddDbContext<AspnetRunContext>(c =>
    //    c.UseSqlServer(configuration.GetConnectionString("AspnetRunConnection"), x => x.MigrationsAssembly("AspnetRun.Web")));
}

static void ConfigureIdentity(IServiceCollection services)
{
    services.AddDefaultIdentity<IdentityUser>()
        .AddDefaultUI()
        .AddEntityFrameworkStores<AspnetRunContext>();

    services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    });
}
