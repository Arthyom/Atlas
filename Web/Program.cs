using Core.Helpers;
using Core.MiddleWares;
using Core.Services.Implementations;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using InertiaCore.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext(builder.Configuration);


// Add services to the container.
builder.Services.AddInertia();
builder.Services.AddViteHelper(options =>
{
    options.PublicDirectory = "wwwroot";
    options.BuildDirectory = "build";
    options.HotFile = "hot";
    options.ManifestFilename = "manifest.json";
});


builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddAutoMapper();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IAtlasBaseServiceMixed<,,>), typeof(AtlasBaseServiceMixed<,,>));



builder.Services.AddScoped(typeof(ISeederFacade<>), typeof(SeederFacade<>));

builder.Services.AddScoped<IProductoService, ProductoService>(); 

builder.Services.AddScoped<IProductoMixedService, ProductoMixedService>();    




builder.Services.AddControllersWithViews();


var app = builder.Build();


app.UseInertia();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}"
);

// app.MapControllerRoute(
//     name: "admin",
//     pattern: "admin/{controller}/{action=Index}/{id?}",
//     defaults: new { controller = "Admin", action = "Index" }
// );

// app.MapControllerRoute(
//     name: "json-admin",
//     pattern: "admin/{controller}/json/{action=List}/{id?}"
// );

// app.MapControllerRoute(
//     name: "json-single",
//     pattern: "{controller}/json/{action=List}/{id?}"
// );


// app.MapControllerRoute(
//     name: "file-admin",
//     pattern: "admin/{controller}/file/{action=Get}/{identifier}"
// );

// app.MapControllerRoute(
//     name: "file-single",
//     pattern: "{controller}/file/{action=Get}/{identifier}"
// );

app.MapFallbackToFile("index.html");


app.UseMiddleware<AuthSharedMiddleWrare>();

app.Run();

