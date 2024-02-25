using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Common
{
    public class ExcelToHtmlHepler
    {
        public static void ExportTableCode()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
            // Excel文件路径
            string excelFilePath = "2023.01.11.xlsx";

            // 创建一个HTML文件
            string htmlFilePath = "Output.html";

            FileInfo excelFile = new FileInfo(excelFilePath);

            using (ExcelPackage package = new ExcelPackage(excelFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                string html = "<!DOCTYPE html><html><head><title>Excel to HTML</title></head><body><table border=\"1\">";

                // 循环遍历所有行
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    html += "<tr>";

                    // 循环遍历所有列
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        var cell = worksheet.Cells[row, col];

                        // 如果是合并单元格的起始单元格，获取合并的行列数
                        int rowspan = 1;
                        int colspan = 1;
                        if (cell.Merge)
                        {
                            rowspan = cell.Start.Row - cell.End.Row + 1;
                            colspan = cell.Start.Column - cell.End.Column + 1;
                        }

                        // 添加单元格内容到HTML
                        if (rowspan > 1 || colspan > 1)
                        {
                            html += $"<td rowspan=\"{rowspan}\" colspan=\"{colspan}\">{cell.Text}</td>";
                        }
                        else
                        {
                            html += $"<td>{cell.Text}</td>";
                        }
                    }

                    html += "</tr>";
                }

                html += "</table></body></html>";

                // 将HTML写入文件
                File.WriteAllText(htmlFilePath, html);
            }

            Console.WriteLine("Excel转换为HTML完成！");
        }
    }
}
