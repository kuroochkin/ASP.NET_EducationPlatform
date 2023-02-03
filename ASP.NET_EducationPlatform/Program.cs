using ASP.NET_EducationPlatform.Infrastructure;
using ASP.NET_EducationPlatform.Infrastructure.Conventions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // сервисы
services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});

var app = builder.Build();

//__________________________________//

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // вывод ошибок
}

app.UseRouting(); // система маршрутизации
app.UseStaticFiles(); // статические файлы wwwroot
app.UseMiddleware<TestMiddleware>(); // cвое ПО

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
