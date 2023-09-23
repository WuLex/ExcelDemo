using ExcelProject.Common;
using ExcelProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// 访问托管环境
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

    // 该路由匹配以 "DownloadFiles/" 开头的 URL，后面可以跟任意数量的段。
    // 当访问匹配的 URL 时，它将路由到 "ExcelData" 控制器中的 "DownloadFiles" 操作方法，
    // 并且 URL 的捕获段将作为操作方法中的参数可用。
    endpoints.MapControllerRoute(
        name: "download",
        pattern: "/DownloadFiles/{*filePath}",
        defaults: new { controller = "ExcelData", action = "DownloadFiles" });

    //直接响应输出excel文件流
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
