using CustomerCRUDWebApp.Domain.CustomerManagement;
using CustomerCRUDWebApp.Domain.CustomerManagement.Entities;
using CustomerCRUDWebApp.Domain.CustomerManagement.Interfaces;
using CustomerCRUDWebApp.Domain.CustomerManagement.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;



static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<CustomerManagementDBContext>();

    db.Customers.Add(new Customer("Leo", "Gem","home",string.Empty));
    db.Customers.Add(new Customer("Ares", "Tau","Krungkrung","09320131314"));
    db.Customers.Add(new Customer("Virgo", "Pi", string.Empty,"09365842146"));
    db.SaveChanges();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CustomerManagementDBContext>
(o => o.UseInMemoryDatabase("CustomerDB"));
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var assembly = AppDomain.CurrentDomain.Load("CustomerCRUDWebApp.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<CustomerManagementDBContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
AddCustomerData(app);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("corsapp");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
