using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AK.Data;
using AK.Areas.Identity.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AKContextConnection") ?? throw new InvalidOperationException("Connection string 'AKContextConnection' not found.");

builder.Services.AddDbContext<AKContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AKUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AKContext>();

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorPagesOptions(options => {
    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Identity/Account/Login}/{id?}");
app.MapRazorPages();

app.Run();
