using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Common
{
    internal class MergeHelper
    {
        public static void ExportData()
        {
            var filePath = "ComplexReport.xlsx";
            // 设置LicenseContext属性为当前应用程序域
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // 或者 LicenseContext.Commercial

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 合并单元格,4个单元格
                worksheet.Cells["A1:B2"].Merge = true;
                worksheet.Cells["A1"].Value = "Merged Cells";
                worksheet.Cells["A1"].Style.Font.Bold = true;

                // 合并行
                worksheet.Cells["C3:D3"].Merge = true;
                worksheet.Cells["C3"].Value = "Merged Row";
                worksheet.Cells["C3"].Style.Font.Bold = true;

                // 合并列
                worksheet.Cells["E4:E6"].Merge = true;
                worksheet.Cells["E4"].Value = "Merged Column";
                worksheet.Cells["E4"].Style.Font.Bold = true;

                // 设置合并后的单元格内容
                worksheet.Cells["A1:E6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:E6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                // 保存Excel文件
                File.WriteAllBytes(filePath, package.GetAsByteArray());

                Console.WriteLine($"Excel报表已生成并保存到 {filePath}");
            }
        }
    }
}
