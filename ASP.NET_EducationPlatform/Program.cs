var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // сервисы
services.AddControllersWithViews();

var app = builder.Build();

//__________________________________//

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // вывод ошибок
}

app.UseRouting(); // система маршрутизации
app.UseStaticFiles(); // статические файлы wwwroot


app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
