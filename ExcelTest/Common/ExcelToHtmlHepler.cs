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
                var mergeCell = new HashSet<int>();

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
                            //获取工作簿中所有 MergeCell 索引号
                            var id = worksheet.GetMergeCellId(row, col);
                            //如果根据MergeCell添加过td标签，就直接跳过
                            if (mergeCell.Contains(id)) continue;
                            mergeCell.Add(id);

                            //获取单元格合并的行数和列数
                            rowspan = worksheet.Cells[worksheet.MergedCells[id - 1]].Rows;
                            colspan = worksheet.Cells[worksheet.MergedCells[id - 1]].Columns;
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
