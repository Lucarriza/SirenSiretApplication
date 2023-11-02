using Microsoft.EntityFrameworkCore;
using SIRENSIRETApplication.Server.DataAccess;
using SIRENSIRETApplication.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add DbContext and other services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<DomainModelSqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IDataAccessProvider, DataAccessSqlProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();