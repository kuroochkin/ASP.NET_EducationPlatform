var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var services = builder.Services; // �������
services.AddControllersWithViews();


app.MapGet("/", () => "Hello World!");
app.Run();
