using ASP.NET_EducationPlatform.Infrastructure;
using ASP.NET_EducationPlatform.Infrastructure.Conventions;
using ASP.NET_EducationPlatform.Services.InMemory;
using ASP.NET_EducationPlatform.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // �������
services.AddSingleton<ITeacherData, InMemoryTeacherData>();
services.AddSingleton<IStudentData, InMemoryStudentData>();

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
