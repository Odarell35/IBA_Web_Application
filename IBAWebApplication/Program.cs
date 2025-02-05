using IBAWebApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//create web application

//  This retrieves the database connection string from the appsettings.json file.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));  //   tells ASP.NET Core to use SQL Server as the database.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();  //Exception handling

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();  //  enables MVC functionality,

var app = builder.Build();   //build the web application after setting up all services

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseStaticFiles();  // serve static files

app.UseRouting();        // Enables URL routing ( determines how URLs are mapped to controllers and views.)

app.UseAuthorization();   // Enables authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();     // Starts the application