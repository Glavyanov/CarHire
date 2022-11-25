using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using CarHire.Infrastructure.Data;
using CarHire.Infrastructure.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount =
    builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
    options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:RequireUniqueEmail");

    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
    options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:RequiredUniqueChars");
    options.Password.RequireNonAlphanumeric =
    builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:RequireUppercase");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:RequireLowercase");
    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/User/Login";
    opt.Cookie.HttpOnly = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas", 
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default", 
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
