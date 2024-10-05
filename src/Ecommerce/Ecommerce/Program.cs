using BeautyStore.Application.Extensions;
using BeautyStore.Infrastructure.Extensions;
using BeautyStore.Infrastructure.Seeders;
using Ecommerce.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();
var userRolesSeeder = scope.ServiceProvider.GetRequiredService<UserRolesSeeder>();
var superUsersSeeder = scope.ServiceProvider.GetRequiredService<SuperUsersSeeder>();

await userRolesSeeder.Seed();
await superUsersSeeder.Seed("Admin@123");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.AddMiddlewares();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
