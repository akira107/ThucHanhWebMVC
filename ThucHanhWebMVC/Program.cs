using Microsoft.EntityFrameworkCore;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//khai bao
var connectionString = builder.Configuration.GetConnectionString("QlbanValiContext");
builder.Services.AddDbContext<QlbanValiContext>(x=>x.UseSqlServer(connectionString));

builder.Services.AddScoped<ILoaiSpRepository, LoaiSpRepository>();
//login
builder.Services.AddSession();

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
//khai bao
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
