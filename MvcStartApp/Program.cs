using Microsoft.EntityFrameworkCore;
using MvcStartApp.Middlewares;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Repository;

var builder = WebApplication.CreateBuilder(args);
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(options=>options.UseSqlServer(connection));
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IRequestRepository,RequestRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

app.UseStaticFiles();

app.UseRouting();



app.MapDefaultControllerRoute();


app.Run();
