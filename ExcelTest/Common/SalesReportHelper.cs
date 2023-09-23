using ExcelTest.Models;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Common
{
    public class SalesReportHelper
    {
        public static void GenerateSalesReport(string filePath, List<SalesData> data)
        {
            // 设置LicenseContext属性为当前应用程序域
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // 或者 LicenseContext.Commercial

            // 创建一个新的Excel包
            using var package = new ExcelPackage();

            // 添加一个工作表
            var worksheet = package.Workbook.Worksheets.Add("销售人员业绩表");

            // 设置列宽度
            for (int i = 1; i <= 9; i++)
            {
                worksheet.Column(i).Width = 12;
            }

            // 合并单元格
            worksheet.Cells["A1:I1"].Merge = true;
             
            // 设置标题
            worksheet.Cells["A1"].Value = "销售人员业绩表";
            worksheet.Cells["A1"].Style.Font.Size = 20;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


            // 合并单元格并设置文本居中
            worksheet.Cells["D3:E3"].Merge = true;
            worksheet.Cells["D3:E3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells["F3:G3"].Merge = true;
            worksheet.Cells["F3:G3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells["H3:I3"].Merge = true;
            worksheet.Cells["H3:I3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


            // 填充表头
            worksheet.Cells["A3"].Value = "日期";
            worksheet.Cells["B3"].Value = "单位";
            worksheet.Cells["C3"].Value = "单价";
            worksheet.Cells["D3"].Value = "上月销售";
            worksheet.Cells["D4"].Value = "货号";
            worksheet.Cells["E4"].Value = "金额";
            worksheet.Cells["F3"].Value = "本月销售";
            worksheet.Cells["F4"].Value = "货号";
            worksheet.Cells["G4"].Value = "金额";
            worksheet.Cells["H3"].Value = "本月结存";
            worksheet.Cells["H4"].Value = "货号";
            worksheet.Cells["I4"].Value = "金额";

            // 设置表头样式
            using (var range = worksheet.Cells["A3:I4"])
            {
                range.Style.Font.Bold = true;
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.DarkSlateBlue);
                range.Style.Font.Color.SetColor(System.Drawing.Color.White);
                range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            }

            int row = 5; // 从第五行开始填充数据

            foreach (var item in data)
            {
                // 填充日期、单位和单价
                worksheet.Cells[row, 1].Value = item.Date;
                worksheet.Cells[row, 2].Value = item.Unit;
                worksheet.Cells[row, 3].Value = item.Price;

                // 初始化当前行的列索引
                int col = 4;

                // 填充上月销售数据
                foreach (var sale in item.LastMonthSales)
                {
                    worksheet.Cells[row, col].Value = sale.ProductCode;
                    col++;
                    worksheet.Cells[row, col].Value = sale.Amount;
                    col++;
                }

                // 填充本月销售数据
                foreach (var sale in item.CurrentMonthSales)
                {
                    worksheet.Cells[row, col].Value = sale.ProductCode;
                    col++;
                    worksheet.Cells[row, col].Value = sale.Amount;
                    col++;
                }

                // 填充本月结存数据
                foreach (var balance in item.CurrentMonthBalance)
                {
                    worksheet.Cells[row, col].Value = balance.ProductCode;
                    col++;
                    worksheet.Cells[row, col].Value = balance.Amount;
                    col++;
                }

                // 增加行数，准备填充下一行数据
                row++;
            }


            #region 添加折线图
            // 添加折线图
            var chart = worksheet.Drawings.AddChart("折线图", eChartType.LineMarkers);
            chart.SetPosition(15, 0, 3, 0);
            chart.SetSize(800, 400);
            chart.Title.Text = "销售业绩趋势";

            // 获取日期列的数据
            var dates = data.Select(d => DateTime.Parse(d.Date)).ToArray();

            // 添加日期作为横坐标标签
            var xAxis = chart.Series.Add(worksheet.Cells["A5:A" + (5 + data.Count)], worksheet.Cells["A5:A" + (5 + data.Count)]);
            xAxis.Header = "日期";

            // 添加本月货号金额作为数据系列
            var currentMonthSeries = chart.Series.Add(worksheet.Cells["G5:G" + (5 + data.Count)], worksheet.Cells["A5:A" + (5 + data.Count)]);
            currentMonthSeries.Header = "本月金额";

            // 添加上月货号金额作为数据系列
            var lastMonthSeries = chart.Series.Add(worksheet.Cells["E5:E" + (5 + data.Count)], worksheet.Cells["A6:A" + (5 + data.Count)]);
            lastMonthSeries.Header = "上月金额";
            #endregion


            // 保存Excel文件
            var fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

            Console.WriteLine("Excel文件已生成：" + filePath);
        }
    }
}