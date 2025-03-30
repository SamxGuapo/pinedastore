using PinedaStore.Models;
using PinedaStore.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioPdf, Repositoriopdf>();
builder.Services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddTransient<IRepositorioHome, RepositorioHome>();
builder.Services.AddTransient<IRepositorioProducto, RepositorioProducto>();
builder.Services.AddTransient<IRepositorioProvedor, RepositorioProvedor>();
builder.Services.AddTransient<IRepositorioCompras, RepositorioCompras>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IcarritoServicio, carritoServicio>();
builder.Services.AddTransient<productoSeleccionados>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Carrusel}/{action=slider}/{id?}");

app.Run();
