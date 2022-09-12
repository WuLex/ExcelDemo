using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text.RegularExpressions;

namespace ExcelProject.Common
{
    public class ExcelHelper
    {
        /// <summary>
        /// List导出excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataList">数据</param>
        /// <param name="headers">表头</param>
        /// <param name="hasBorlder">单元格是否有边框</param>
        /// <returns></returns>
        public static string CreateExcelFromListEx<T>(List<T> dataList, string sheetName, List<ExcelHeader> headers, bool hasBorlder = false)
        {
            if (headers == null)
            {
                throw new Exception("表头信息不能为空！");
            }
            string sWebRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot\\Download");//如果用浏览器url下载的方式  存放excel的文件夹一定要建在网站首页的同级目录下！！！
            if (!Directory.Exists(sWebRootFolder))
            {
                Directory.CreateDirectory(sWebRootFolder);
            }
            string sFileName = $@"tempExcel_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls";
            var path = Path.Combine(sWebRootFolder, sFileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(path);
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage(file);
            //创建sheet
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);
            var headerRowCount = 1;//标题占的行数
            headers.ForEach(p =>
            {
                var rowNum = int.Parse(Regex.Replace(p.Adress, "[a-z]", "", RegexOptions.IgnoreCase));
                if (rowNum > headerRowCount)
                {
                    headerRowCount = rowNum;
                }
            });
            if (hasBorlder)//边框
            {
                var dataRows = dataList.Count() + headerRowCount;
                string modelRange = "A1:" + Regex.Replace(headers.LastOrDefault().Adress, "[0-9]", "", RegexOptions.IgnoreCase) + dataRows.ToString();
                var modelTable = worksheet.Cells[modelRange];
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            worksheet.Cells[headerRowCount, 1].LoadFromCollection(dataList, true);
            //表头字段
            for (int i = 0; i < headers.Count; i++)
            {
                worksheet.Cells[headers[i].Adress].Value = headers[i].Value;
                if (!string.IsNullOrWhiteSpace(headers[i].MergeArea))
                {
                    worksheet.Cells[headers[i].MergeArea].Merge = true;
                }
                worksheet.Cells[headers[i].Adress].Style.Font.Size = 12; //字体大小
                worksheet.Cells[headers[i].Adress].Style.Font.Bold = true; //设置粗体
                worksheet.Cells[headers[i].Adress].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; //水平居中对齐
                worksheet.Cells[headers[i].Adress].Style.VerticalAlignment = ExcelVerticalAlignment.Center; //垂直居中对齐
                if (headers[i].Width > 0)
                {
                    worksheet.Column(ColumnIndex(headers[i].Adress)).Width = headers[i].Width;
                }
            }
            var objs = worksheet.Cells;
            for (int i = 1; i <= dataList.Count + 2; i++)
            {
                for (int j = 1; j <= headers.Count + 1; j++)
                {
                    objs[i, j].Value = objs[i, j].Value == null ? "" : objs[i, j].Value.ToString(); //null值设置为""
                }
            }
            package.Save();
            return path;//返回文件路径
        }

        /// <summary>
        /// 根据单元格地址计算出单元格所在列的索引
        /// </summary>
        /// <param name="reference">单元格地址，示例A1,AB2</param>
        /// <returns></returns>
        private static int ColumnIndex(string reference)
        {
            int ci = 0;
            reference = reference.ToUpper();
            for (int ix = 0; ix < reference.Length && reference[ix] >= 'A'; ix++)
                ci = (ci * 26) + ((int)reference[ix] - 64);
            return ci;
        }
    }

    public class ExcelHeader
    {
        /// <summary>
        /// 单元格地址A1,B2等
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// 单元格值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 单元格合并区域,示例A1:B2，为空表示不合并
        /// </summary>
        public string MergeArea { get; set; }

        /// <summary>
        /// 列宽度，合并列不需要指定宽度，示例：
        /// | A |
        /// |B|C|
        /// 表头A是单元格B和单元格C合并而来，不需要指定宽度，只指定B和C宽度即可
        /// </summary>
        public int Width { get; set; }
    }
}