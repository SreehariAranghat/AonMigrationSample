using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add framework services.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
	builder.Services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Add Kendo UI services to the services container
builder.Services.AddKendo();


builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddResponseCompression();
builder.Services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                });
/*builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".LibraryManagement.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});*/

builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle("/css/bundle.css", "Content/*.css");
    pipeline.AddJavaScriptBundle("/js/bundle.js", "Scripts/*.js");

    pipeline.MinifyJsFiles();

  
});
var app = builder.Build();

//app.UseSession();
app.UseStaticFiles();
app.UseWebOptimizer();
app.UseResponseCompression();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();


app.Run();
