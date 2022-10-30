using BulkyBookWeb.Data;        /*Henviser til bruk av "Data" mappen.*/
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.           Husk å gjøre dette før du bygger "Builder".
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        /*Bygge Tjenester som vil legge til DBContext i ApplicationDbContext hvor options*/
        /*blir definert som: bruke SqlServer med tilkoblingsstrengen: som ligger i:*/
        /*"ConnectionStrings" blokken i "appsettings.json".*/
    builder.Configuration.GetConnectionString("DefaultConnection") 
        /*Builder konfigurerer GetConnectionString metode som er en spesiell metode, som henter*/
        /*koblingsstrengen som heter "DefaultConnection" i "appsettings.json"*/
            /*Nå som "Program.cs" er konfigurert for SQLDataBase, neste steg er å opprette SQL DataBase og tabell.*/
    ));
        
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
