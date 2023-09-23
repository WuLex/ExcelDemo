using ExcelProject.Common;
using ExcelProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// �����йܻ���
var env = builder.Environment;

builder.Services.AddDbContext<NewPetContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ChipDbDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChipDbConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // ��·��ƥ���� "DownloadFiles/" ��ͷ�� URL��������Ը����������ĶΡ�
    // ������ƥ��� URL ʱ������·�ɵ� "ExcelData" �������е� "DownloadFiles" ����������
    // ���� URL �Ĳ���ν���Ϊ���������еĲ������á�
    endpoints.MapControllerRoute(
        name: "download",
        pattern: "/DownloadFiles/{*filePath}",
        defaults: new { controller = "ExcelData", action = "DownloadFiles" });

    //ֱ����Ӧ���excel�ļ���
    //endpoints.MapGet("/DownloadFiles/{fileName}", async context =>
    //{
    //    var fileName = context.Request.RouteValues["fileName"]?.ToString();
    //    if (!string.IsNullOrEmpty(fileName))
    //    {
    //        var filePath = Path.Combine(env.WebRootPath, "DownloadFiles", fileName);
    //        if (File.Exists(filePath))
    //        {
    //            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    //            await context.Response.Body.CopyToAsync(stream);
    //            stream.Close();
    //        }
    //    }
    //});
});
 
app.Run();
