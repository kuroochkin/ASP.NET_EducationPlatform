var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var services = builder.Services; // сервисы
services.AddControllersWithViews();


app.MapGet("/", () => "Hello World!");
app.Run();
