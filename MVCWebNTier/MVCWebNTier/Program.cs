using Microsoft.EntityFrameworkCore;
using MVCWebNTier.Data.Context;
using Repository;
using Service;
using Validators;
using Microsoft.AspNetCore.Identity;
using MVCWebNTier.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyFirstMVCAppContext"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));


builder.Services.AddDbContext<MVCWebNTierIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCWebNTierIdentityContextConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MVCWebNTierIdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ISchoolRepository, SchoolRepository>();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ISchoolValidator, SchoolValidator>();




var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();

    dbContext.Database.EnsureCreated();

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
