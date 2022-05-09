using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using food_manager.Models.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<food_managerContext>(options =>
       options.UseSqlServer(
           //appsettings.json‚©‚çˆø”–¼‚ÌÚ‘±•¶Žš—ñ‚ðŽæ“¾(appsettings.json‚Ì11s–Ú‚Ì’l)
           builder.Configuration.GetConnectionString("DefaultConnection")
       )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("MyCookieAuthenticationScheme")
    .AddCookie("MyCookieAuthenticationScheme", options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

var app = builder.Build();

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
    pattern: "{controller=Users}/{action=UserSetting}/{id?}");

app.Run();
