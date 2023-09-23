using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Drawing;
using ExcelProject.Models;
using NPOI.HPSF;

namespace ExcelProject.Common
{
    public class ExcelReportHelper
    {
        //输出到本地excel
        public static void GenerateReportLocal(string fileName, List<SalesData> data)
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("复杂报表");

                // 设置标题
                var titleCell = worksheet.Cells["A1:F1"];
                titleCell.Merge = true;
                titleCell.Value = "复杂报表示例";
                titleCell.Style.Font.Size = 18;
                titleCell.Style.Font.Bold = true;
                titleCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                titleCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                titleCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                // 添加日期
                worksheet.Cells["A2"].Value = "日期:";
                worksheet.Cells["B2"].Value = DateTime.Now.ToShortDateString();
                worksheet.Cells["B2"].Style.Font.Bold = true;

                // 设置列宽
                worksheet.Column(1).Width = 20;
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 15;
                worksheet.Column(5).Width = 15;
                worksheet.Column(6).Width = 20;

                // 添加表头
                worksheet.Cells["A4"].Value = "项目";
                worksheet.Cells["B4"].Value = "数量";
                worksheet.Cells["C4"].Value = "单价";
                worksheet.Cells["D4"].Value = "总价";
                worksheet.Cells["E4"].Value = "销售人员";

                // 添加数据
                //var data = new[]
                //{
                //new { Item = "物品1", Quantity = 10, Price = 20.00, Salesperson = "销售员1", Note = "备注1" },
                //new { Item = "物品2", Quantity = 5, Price = 30.00, Salesperson = "销售员2", Note = "备注2" },
                //new { Item = "物品3", Quantity = 8, Price = 25.00, Salesperson = "销售员3", Note = "备注3" },
                // };

                int row = 5;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.ItemName;
                    worksheet.Cells[row, 2].Value = item.Quantity;
                    worksheet.Cells[row, 3].Value = item.Price;
                    worksheet.Cells[row, 4].Formula = $"B{row}*C{row}";
                    worksheet.Cells[row, 5].Value = item.Salesperson;
                    row++;
                }

                // 添加总计
                var totalRow = row;
                worksheet.Cells[totalRow, 3].Value = "总计:";
                worksheet.Cells[totalRow, 4].Formula = $"SUM(D5:D{totalRow - 1})";
                worksheet.Cells[totalRow, 4].Style.Font.Bold = true;

                // 添加边框
                var dataRange = worksheet.Cells[$"A4:F{totalRow}"];
                dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // 添加条件格式
                var totalPriceColumn = worksheet.Cells[$"D5:D{totalRow}"];
                var totalPriceRule = totalPriceColumn.ConditionalFormatting.AddThreeColorScale();
                totalPriceRule.LowValue.Color = Color.Red;
                totalPriceRule.MiddleValue.Color = Color.Yellow;
                totalPriceRule.HighValue.Color = Color.Green;

                // 添加一个柱状图
                var chart = worksheet.Drawings.AddChart("Chart", eChartType.ColumnClustered);
                chart.SetPosition(0, 7, 7, 16);
                chart.SetSize(800, 400);
                chart.Title.Text = "销售数据";
                chart.Series.Add(worksheet.Cells[$"B5:B{totalRow}"], worksheet.Cells[$"A5:A{totalRow}"]);

                // 保存Excel文件
                var excelBytes = package.GetAsByteArray();
                File.WriteAllBytes($"{(string.IsNullOrEmpty(fileName)?"复杂报表" : fileName)}.xlsx", excelBytes);
            }
        }


        public static byte[] GenerateReport(List<SalesData> data)
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("复杂报表");

                // 设置标题
                var titleCell = worksheet.Cells["A1:F1"];
                titleCell.Merge = true;
                titleCell.Value = "复杂报表示例";
                titleCell.Style.Font.Size = 18;
                titleCell.Style.Font.Bold = true;
                titleCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                titleCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                titleCell.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                // 添加日期
                worksheet.Cells["A2"].Value = "日期:";
                worksheet.Cells["B2"].Value = DateTime.Now.ToShortDateString();
                worksheet.Cells["B2"].Style.Font.Bold = true;

                // 设置列宽
                worksheet.Column(1).Width = 20;
                worksheet.Column(2).Width = 15;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 15;
                worksheet.Column(5).Width = 15;
                worksheet.Column(6).Width = 20;

                // 添加表头
                worksheet.Cells["A4"].Value = "项目";
                worksheet.Cells["B4"].Value = "数量";
                worksheet.Cells["C4"].Value = "单价";
                worksheet.Cells["D4"].Value = "总价";
                worksheet.Cells["E4"].Value = "销售人员";

                int row = 5;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.ItemName;
                    worksheet.Cells[row, 2].Value = item.Quantity;
                    worksheet.Cells[row, 3].Value = item.Price;
                    worksheet.Cells[row, 4].Formula = $"B{row}*C{row}";
                    worksheet.Cells[row, 5].Value = item.Salesperson;
                    row++;
                }

                // 添加总计
                var totalRow = row;
                worksheet.Cells[totalRow, 3].Value = "总计:";
                worksheet.Cells[totalRow, 4].Formula = $"SUM(D5:D{totalRow - 1})";
                worksheet.Cells[totalRow, 4].Style.Font.Bold = true;

                // 添加边框
                var dataRange = worksheet.Cells[$"A4:F{totalRow}"];
                dataRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                dataRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // 添加条件格式
                var totalPriceColumn = worksheet.Cells[$"D5:D{totalRow}"];
                var totalPriceRule = totalPriceColumn.ConditionalFormatting.AddThreeColorScale();
                totalPriceRule.LowValue.Color = Color.Red;
                totalPriceRule.MiddleValue.Color = Color.Yellow;
                totalPriceRule.HighValue.Color = Color.Green;

                // 添加一个柱状图
                var chart = worksheet.Drawings.AddChart("Chart", eChartType.ColumnClustered);
                chart.SetPosition(0, 7, 7, 16);
                chart.SetSize(800, 400);
                chart.Title.Text = "销售数据";
                chart.Series.Add(worksheet.Cells[$"B5:B{totalRow}"], worksheet.Cells[$"A5:A{totalRow}"]);

                // 以字节数组形式返回 Excel 数据
                return package.GetAsByteArray();
            }
        }
    }
}
