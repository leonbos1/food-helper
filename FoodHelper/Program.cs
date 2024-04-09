using FoodHelper.Data;
using FoodHelper.Data.Repositories;
using FoodHelper.Logic.Services;
using FoodHelper.Logic.Services.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FoodContext>(options =>
{
    var connectionString = builder.Configuration["FoodContext"];

    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FoodRepository>();
builder.Services.AddScoped<TokenRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<FoodRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
