using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.RumahAqiqah.Application.Repository;
using RAS.Bootcamp.RumahAqiqah.Cms.Controllers;
using RAS.Bootcamp.RumahAqiqah.Data;
using RAS.Bootcamp.RumahAqiqah.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Data dummy

// Role role1 = new Role {Code="CM", Name="Customer", Description="Konsumen"};
// Role role2 = new Role {Code="ADM-1", Name="Admin Keuangan", Description="Mengatur laporan keuangan"};
// Role role3 = new Role {Code="ADM-2", Name="Admin Database", Description="Mengatur database"};

// Account account1 = new Account {Username="abdulghani", Password="1234", LastLogin=DateTime.Now};
// Account account2 = new Account {Username="donisalmanan", Password="doni", LastLogin=DateTime.Now};

// User user1 = new User {AccountId=1, Name="Abdul", RoleId=1};
// User user2 = new User {AccountId=2, Name="Doni", RoleId=1};

app.Run();
