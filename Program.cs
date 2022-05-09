using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using food_manager.Models.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<food_managerContext>(options =>
       options.UseSqlServer(
           //appsettings.json����������̐ڑ���������擾(appsettings.json��11�s�ڂ̒l)
           builder.Configuration.GetConnectionString("DefaultConnection")
       )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
