using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

// services.AddAuthentication()
// .AddGoogle(options => {
//     options.ClientId = "304413053018-rcfnmho1e739smiq30de3aefum5jp4ni.apps.googleusercontent.com";
//     options.ClientSecret = "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";
// })
// .AddCookie()
// .AddOpenIdConnect(options => {
//     options.SignInScheme = "Cookies";
//        options.Authority = "-your-identity-provider-";
//        options.RequireHttpsMetadata = true;
//        options.ClientId = "-your-clientid-";
//        options.ClientSecret = "-client-secret-from-user-secrets-or-keyvault";
//        options.ResponseType = "code";
//        options.UsePkce = true;
//        options.Scope.Add("profile");
//        options.SaveTokens = true;
//        options.GetClaimsFromUserInfoEndpoint = true;
//        options.ClaimActions.MapUniqueJsonKey("username","username");
//        options.ClaimActions.MapUniqueJsonKey("gender", "gender");
//        options.TokenValidationParameters = new TokenValidationParameters
//         {
//           NameClaimType = "email"
//        //, RoleClaimType = "role"
//          };
// });
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
