using DiscussionLibraryGroup8;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcGroup8.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); builder.Services
    .AddControllersWithViews(); var app = builder.Build();
var scope = app.Services.CreateScope(); var services = scope.ServiceProvider; try { InitialDatabase.SeedDatabase(services);
} catch (Exception serviceException) { var logger = services.GetRequiredService<ILogger<Program>>(); logger.LogError(serviceException.Message, "Error from Db, User or Role Service"); } 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

//3 Services: Database, AppUsers, Roles

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    InitialDatabase
}
catch (Exception serviceException)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(serviceException.Message, "Error from DB, User or Role service");
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { app.UseMigrationsEndPoint();
} else { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); 
} app.UseStaticFiles(); app.UseRouting(); app.UseAuthentication(); 
app.UseAuthorization(); app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();

