using prueba1;
using prueba1.Dato;
using prueba1.Interfaces;
using prueba1.Logicas;
using prueba1.Models;
using prueba1.Repositorio.IRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>();

//
builder.Services.AddAutoMapper(typeof(mappingConfig));

builder.Services.AddScoped<IlogicaCustomer, logicaCustomer>();
builder.Services.AddScoped<IDatoCustomer<Customer>, datoCustomer>();

// generico
builder.Services.AddScoped<ICustomerRepositorio, CustomerRepositorio>();
builder.Services.AddScoped<IOrderRepositorio, OrderRepositorio>();

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
