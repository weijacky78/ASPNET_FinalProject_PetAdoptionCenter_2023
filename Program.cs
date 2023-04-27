using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var dbmsVersion = new MariaDbServerVersion(builder.Configuration.GetValue<string>("MariaDbVersion"));//load the mariadb version
var connectionString = builder.Configuration.GetConnectionString("FinalProjectDb");//load the connection string
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ProjectContext>(opt =>
{//add the dbcontext
    opt.UseMySql(connectionString, dbmsVersion);//use mysql
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ProjectContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
