var builder = WebApplication.CreateBuilder(args);
//stöd för MVC
builder.Services.AddControllersWithViews();
var app = builder.Build();

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
