var builder = WebApplication.CreateBuilder(args);
//stöd för MVC
builder.Services.AddControllersWithViews();

//för att sessions ska fungera
builder.Services.AddDistributedMemoryCache();

//lägg till block för sessions
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

//för att Sessions ska fungera
app.UseSession();

//aktivera statiska filer (wwwroot)
app.UseStaticFiles();

//aktivera routing
app.UseRouting();

//Routing
app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

//kör igång app
app.Run();
