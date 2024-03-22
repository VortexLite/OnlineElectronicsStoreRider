using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineElectronicsStore.DAL;
using OnlineElectronicsStore.DAL.Interfaces;
using OnlineElectronicsStore.DAL.Repositories;
using OnlineElectronicsStore.DAL.Seeds;
using OnlineElectronicsStore.Service.Implementations;
using OnlineElectronicsStore.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using OnlineElectronicsStore.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DbInitializer>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<INavigationRepository, NavigationRepository>();
builder.Services.AddScoped<INavigationService, NavigationService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IProducerService, ProducerService>();

builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });

builder.Services.AddControllersWithViews();



var app = builder.Build();

await SeedData(app);

async Task SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DbInitializer>();
        
        await service.SeedCategories();
        await service.SeedDeliveryTypes();
        await service.SeedProducers();
        await service.SeedNavigations();
        await service.SeedStatusDeliveries();
        await service.SeedCategoryReviews();
        await service.SeedProducts();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id}");

app.Run();