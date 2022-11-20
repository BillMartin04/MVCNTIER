using Microsoft.EntityFrameworkCore;
using MVCWebNTier.Data.Context;
using Repository;
using Service;
using Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyFirstMVCAppContext"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));
//  ?? throw new InvalidOperationException("Connection string 'MyFirstMVCAppContext' not found.")););

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ISchoolRepository, SchoolRepository>();
builder.Services.AddTransient<ISchoolService, SchoolService>();
builder.Services.AddTransient<ISchoolValidator, SchoolValidator>();




var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyFirstMVCAppContext>();

    dbContext.Database.EnsureCreated();

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
