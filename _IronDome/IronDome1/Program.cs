using Microsoft.EntityFrameworkCore;
using IronDome.Contexts;
using IronDome.Hubs;
using IronDome.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// SingalR
builder.Services.AddSignalR();
builder.Services.AddScoped<IAttackService, AttackService>();

// DB
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<IronDomeDbContext>(options => options.UseSqlServer(connectionString));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=IronDome}/{action=ManageAttacks}/{id?}");
app.MapHub<ChatHub>("/chathub");

app.Run();
