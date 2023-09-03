using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DesafioBenner.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DesafioBennerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DesafioBennerContext") ?? throw new InvalidOperationException("Connection string 'DesafioBennerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ControleEstacionamento/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ControleEstacionamento}/{action=Index}/{id?}");

app.Run();
