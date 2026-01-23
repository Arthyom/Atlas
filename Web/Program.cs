using Core.FontResolvers;
using Core.Handlers;
using Core.Helpers;
using Core.MiddleWares;
using Core.Services.Implementations;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Core.Services.Interfaces.Base;
using InertiaCore.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using PdfSharp.Fonts;

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


// builder.Services.AddCors( opts =>
// {
//     opts.AddPolicy(name: "AddingPolicy",
//     configurePolicy: policy =>
//         {
//         policy
//             .AllowAnyOrigin()
//             .AllowAnyMethod();
//         }
//     );
// });

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddAutoMapper();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped(typeof(IAtlasBaseServiceMixed<,,>), typeof(AtlasBaseServiceMixed<,,>));



builder.Services.AddScoped(typeof(ISeederFacade<>), typeof(SeederFacade<>));

builder.Services.AddScoped<IProductoService, ProductoService>(); 
builder.Services.AddScoped<IFontResolver, AtlasFontResolverUbuntu>();


builder.Services.AddScoped<IProductoMixedService, ProductoMixedService>();
builder.Services.AddScoped<ICategoriaMixedService, CategoriaMixedService>();
builder.Services.AddScoped<IVentaMixedService, VentaMixedService>();
builder.Services.AddScoped<IShopMixedService, ShopMixedService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUsuarioMixedService, UsuarioMixedService>();
builder.Services.AddScoped<IEnvioMixedService, EnvioMixedService>();
builder.Services.AddScoped<IPaqueteMixedService, PaqueteMixedService>();
builder.Services.AddScoped<IGuideMixedService, GuideMixedService>();







/// looks wire since doesn't has interface
builder.Services.AddScoped<AtlasHandlerEcartToken, AtlasHandlerEcartToken>();
builder.Services.AddScoped<TokenProvider, TokenProvider>();

builder.Services.AddSession();

builder.Services.AddHttpClient("ShippingServiceCliente");

builder.Services.AddHttpClient("PaymentServiceCliente")
    .AddHttpMessageHandler<AtlasHandlerEcartToken>()
;

builder.Services.AddHttpClient("TokenProvider")
;


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            // Prevent adding ReturnUrl by redirecting directly to login
            context.Response.Redirect("/auth/index");
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = context =>
        {
            // Optionally handle access denied without redirect
            context.Response.StatusCode = 403;
            return Task.CompletedTask;
        }
    };
});


builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/index";
         options.AccessDeniedPath = "/auth/index";
         options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            // Prevent adding ReturnUrl by redirecting directly to login
            context.Response.Redirect("/auth/index");
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = context =>
        {
            // Optionally handle access denied without redirect
            context.Response.StatusCode = 403;
            return Task.CompletedTask;
        }
    };
        // options.ReturnUrlParameter = "";
    });   

builder.Services.AddControllersWithViews( options =>
{
    options.MaxModelBindingCollectionSize = 8024;
});


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

app.ApplyMigrations();
app.ApplySeeders();


app.MapFallbackToFile("index.html");

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
// app.UseMiddleware<AuthSharedMiddleWrare>();


app.Run();

