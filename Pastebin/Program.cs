using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pastebin.Data;
using Pastebin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("PastebinConnection"));
});
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPasteRepo, PasteRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
