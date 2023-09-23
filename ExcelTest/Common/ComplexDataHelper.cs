using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Common
{
    internal class ComplexDataHelper
    {
        public static void ExportData()
        {
            var filePath = "ComplexReport.xlsx";
            // 设置LicenseContext属性为当前应用程序域
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // 或者 LicenseContext.Commercial

            // 创建一个新的ExcelPackage
            using (var package = new ExcelPackage())
            {
                // 添加一个工作表
                var worksheet = package.Workbook.Worksheets.Add("报表");

                // 设置标题
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = "报表标题";
                worksheet.Cells["A1"].Style.Font.Size = 18;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // 添加日期
                worksheet.Cells["A2"].Value = "日期:";
                worksheet.Cells["B2"].Value = DateTime.Now.ToShortDateString();
                worksheet.Cells["B2"].Style.Font.Bold = true;

                // 设置列宽
                worksheet.Column(1).Width = 20;
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 15;

                // 添加表头
                worksheet.Cells["A4"].Value = "项目";
                worksheet.Cells["B4"].Value = "数量";
                worksheet.Cells["C4"].Value = "单价";
                worksheet.Cells["D4"].Value = "总价";

                // 添加数据
                var data = new[]
                {
                new { Item = "物品1", Quantity = 10, Price = 20 },
                new { Item = "物品2", Quantity = 5, Price = 30 },
                new { Item = "物品3", Quantity = 8, Price = 25 },
            };

                int row = 5;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.Item;
                    worksheet.Cells[row, 2].Value = item.Quantity;
                    worksheet.Cells[row, 3].Value = item.Price;
                    worksheet.Cells[row, 4].Formula = $"B{row}*C{row}";
                    row++;
                }

                // 添加总计
                worksheet.Cells[row, 3].Value = "总计:";
                worksheet.Cells[row, 4].Formula = $"SUM(D5:D{row - 1})";
                worksheet.Cells[row, 4].Style.Font.Bold = true;

                // 添加一个柱状图
                var chart = worksheet.Drawings.AddChart("Chart", eChartType.ColumnClustered);
                chart.SetPosition(0, 7, 5, 16);
                chart.SetSize(800, 400);
                chart.Title.Text = "销售数据";
                chart.Series.Add(worksheet.Cells["B5:B7"], worksheet.Cells["A5:A7"]);

                // 保存Excel文件
                var excelBytes = package.GetAsByteArray();
                File.WriteAllBytes("复杂报表.xlsx", excelBytes);
            }
        }
    }
}
