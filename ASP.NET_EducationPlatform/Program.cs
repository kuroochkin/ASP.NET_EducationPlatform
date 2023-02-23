using ASP.NET_EducationPlatform.Infrastructure;
using ASP.NET_EducationPlatform.Infrastructure.Conventions;
using ASP.NET_EducationPlatform.Services;
using ASP.NET_EducationPlatform.Services.InMemory;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatform.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // �������
services.AddSingleton<ITeacherData, InMemoryTeacherData>();
services.AddSingleton<IStudentData, InMemoryStudentData>();
services.AddSingleton<ILessonData, InMemoryLessonData>();
services.AddSingleton<ISubjectData, InMemorySubjectData>();


services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new TestConvention());
});

services.AddDbContext<EducationPlatformDB>(opt => opt
     .UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));// ������ �����������

services.AddTransient<IDbInitializer, DbInitializer>();

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db_initializer.InitializeAsync();
}

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
