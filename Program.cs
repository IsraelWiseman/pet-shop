using Microsoft.EntityFrameworkCore;
using PetShopWebsite.Models;
using PetShopWebsite.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetStoreContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, MyRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    //ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("Default", "{controller=PetShop}/{action=Home}"); 
app.Run();
