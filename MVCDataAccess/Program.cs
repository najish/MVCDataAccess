using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCDataAccess.Data;
using MVCDataAccess.Models;
using MVCDataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();
services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
}).AddEntityFrameworkStores<AppDbContext>();
services.AddAuthentication().AddGoogle(options => {
    options.ClientId = "304413053018-gu9775aeicols229cq6k31pcgj5s4g8s.apps.googleusercontent.com";
    options.ClientSecret = "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";
});
services.AddScoped<IStudentRepository,StudentRepository>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
