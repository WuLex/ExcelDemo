using ExcelProject.Common;
using ExcelProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace ExcelProject.Controllers
{
    public class ExcelDataController : Controller
    {
        // 注入 DbContext
        private readonly ChipDbDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ExcelDataController(ChipDbDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context =context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Export()
        {
            var headers = new List<ExcelHeader>
            {
                new ExcelHeader{ Adress="A1", Value="工号", MergeArea="A1:A2" },
                new ExcelHeader{ Adress="B1", Value="姓名", MergeArea="B1:B2" },
                new ExcelHeader{ Adress="C1", Value="公司", MergeArea="C1:C2", Width=9 },
                new ExcelHeader{ Adress="D1", Value="部门", MergeArea="D1:D2", Width=15 },
                new ExcelHeader{ Adress="E1", Value="工作日出勤", MergeArea="E1:F1" },
                new ExcelHeader{ Adress="E2", Value="出勤天数", Width=11},
                new ExcelHeader{ Adress="F2", Value="出差天数", Width=11},
            };

            List<string> listdata = new List<string>() {
                  "苹果",
                  "香蕉",
                  "橘子"
            };
            //var pathStr =ExcelHelper.CreateExcelFromListEx(listdata, "测试表格", headers);
            var pathStr = ExcelHelper.CreateExcelFromListEx(listdata, "测试表格", headers, _webHostEnvironment);
          
            return Content(pathStr);
        }

        [HttpGet,HttpPost]
        public IActionResult DownloadFiles(string filePath)
        {
            // 存储生成Excel文件的文件夹路径
            var fileFullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);

            if (System.IO.File.Exists(fileFullPath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(fileFullPath);
                return File(fileBytes, "application/octet-stream", Path.GetFileName(fileFullPath));
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult ExportToExcelLocal()
        {
            var salesData = _context.SalesData.ToList(); // 从数据库中查询数据
            ExcelReportHelper.GenerateReportLocal("复杂报表.xlsx", salesData);

            //返回一个成功信息
            return Content("导出成功");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ExportToExcel()
        {
            var salesData = _context.SalesData.ToList();

            // 生成 Excel 数据
            var excelData = ExcelReportHelper.GenerateReport(salesData);

            // 将 Excel 数据作为 FileResult 返回
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "复杂报表.xlsx");
        }
    }
}
