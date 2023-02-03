var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // �������
services.AddControllersWithViews();

var app = builder.Build();

//__________________________________//

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ����� ������
}

app.UseRouting(); // ������� �������������
app.UseStaticFiles(); // ����������� ����� wwwroot


app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
