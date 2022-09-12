using ExcelProject.Common;
using Microsoft.AspNetCore.Mvc;

namespace ExcelProject.Controllers
{
    public class ExcelDataController : Controller
    {
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
            var pathStr =ExcelHelper.CreateExcelFromListEx(listdata, "测试表格", headers);
            return Content(pathStr);
        }

    }
}
