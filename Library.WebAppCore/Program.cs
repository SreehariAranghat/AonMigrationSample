using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc();
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

var app = builder.Build();

//app.UseSession();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();
