using ASP.NET_EducationPlatform.Infrastructure;
using ASP.NET_EducationPlatform.Infrastructure.Conventions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // �������
services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});

var app = builder.Build();

//__________________________________//

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ����� ������
}

app.UseRouting(); // ������� �������������
app.UseStaticFiles(); // ����������� ����� wwwroot
app.UseMiddleware<TestMiddleware>(); // c��� ��

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
