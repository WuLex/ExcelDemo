using ExcelProject.Models;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;

namespace ExcelProject.Controllers
{
    public class ExcelController : Controller
    {
        private readonly NewPetContext _dbContext;

        public ExcelController(NewPetContext dbContext)
        {
            _dbContext = dbContext;
        }

        //会员资料
        private DataTable GetMemberDataTable()
        {
            var q = from mb in _dbContext.tMembers
                    select new
                    {
                        姓名 = mb.fName,
                        性别 = mb.fGender,
                        身分证字号 = mb.fIDCardNumber,
                        帐号 = mb.fAccount,
                        出生日期 = mb.fBirthDate,
                        经济状况 = mb.fEnconomicStatus,
                        电话 = mb.fPhone,
                        电子邮件 = mb.fEMail,
                        居住城市 = mb.tCity.fName,
                        地区 = mb.tRegion.fName,
                        详细地址 = mb.fAddressDetail
                    };

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        //产品售价分布图
        private DataTable GetProductPriceDataTable()
        {
            var model = from p in _dbContext.tProducts.AsEnumerable()
                        where p.tCategory != null
                        group p by p.tCategory.fName into g
                        select new
                        {
                            产品分类 = g.Key,
                            平均价格 = g.Average(p => p.fUnitPrice),
                            //Min = g.Min(p => p.UnitPrice),
                            //Max = g.Max(p => p.UnitPrice),
                        };

            DataTable dt = IEnumerableExtensions.ToDataTable(model);

            return dt;
        }

        //会员人数成长
        private DataTable GetMemberGrowthDataTable()
        {
            var model = from p in _dbContext.tMembers.AsEnumerable()
                        orderby p.fRegisterDate ascending
                        group p by p.fRegisterDate.Value.Year into g
                        select new
                        {
                            年份 = g.Key,
                            会员人数 = g.Count()
                        };

            DataTable dt = IEnumerableExtensions.ToDataTable(model);

            return dt;
        }

        //产品价钱分布
        private DataTable GetALLProductPriceDataTable()
        {
            var model = from p in _dbContext.tProducts.AsEnumerable()

                        select new
                        {
                            产品名称 = p.fName,
                            产品价钱 = p.fUnitPrice,
                            产品待出货 = p.fUnitOnOrder,
                            产品库存 = p.fUnitInStock
                        };

            DataTable dt = IEnumerableExtensions.ToDataTable(model);

            return dt;
        }

        //会员宠物类别分布图
        private DataTable GetPetClassDataTable()
        {
            var q = from ptc in _dbContext.tPetMembers.AsEnumerable()
                    group ptc by ptc.tPetClass.fName into g
                    select new
                    {
                        宠物类别 = g.Key,
                        数量 = g.Count(),
                    };

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        //会员养狗品种分布图
        private DataTable GetDogBreedDataTable()
        {
            var q = from ptb in _dbContext.tPetMembers.AsEnumerable()
                    where ptb.fPetClassID == 1//狗
                    group ptb by ptb.tBreed.fName into g
                    select new
                    {
                        宠物品种 = g.Key,
                        数量 = g.Count(),
                    };

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        //会员养猫品种比例图
        private DataTable GetCatBreedDataTable()
        {
            var q = from ptb in _dbContext.tPetMembers.AsEnumerable()
                    where ptb.fPetClassID == 2//猫
                    group ptb by ptb.tBreed.fName into g
                    select new
                    {
                        宠物品种 = g.Key,
                        数量 = g.Count(),
                    };

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        //PetCoin会员
        private DataTable GetPetCoinDataTable()
        {
            var q = from mem in _dbContext.tMembers.AsEnumerable()
                    orderby mem.fPetCoin descending
                    select new
                    {
                        会员暱称 = mem.fNickName,
                        PetCoin数 = Convert.ToInt32(mem.fPetCoin)
                    };

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        //商品数量排行榜
        private DataTable GetTopProductDataTable()
        {
            var q = (from mem in _dbContext.tOrder_Detail.AsEnumerable()
                     group mem by mem.tProduct.fName into g
                     select new
                     {
                         产品名称 = g.Key,
                         订单数量 = g.Sum(p => p.fQuantity),
                     }).OrderByDescending(p => p.订单数量);

            DataTable dt = IEnumerableExtensions.ToDataTable(q);

            return dt;
        }

        // GET: Excel

        public ActionResult ExportExcel(DataTable datatable)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                //新增worksheet
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("会员资料表");
                //取得资料
                DataTable dt = GetMemberDataTable();
                int length = datatable.Columns.Count;//抓到的length
                //将datatable资料塞进sheet中
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                //自动调整大小
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = ws.Cells["A1:L1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //============================================================================================
                ExcelWorksheet wsProductPrice = package.Workbook.Worksheets.Add("产品种类平均销售价格");

                DataTable dtpp = GetProductPriceDataTable();
                wsProductPrice.Cells["A1"].LoadFromDataTable(dtpp, true);

                //自动调整大小
                wsProductPrice.Cells[wsProductPrice.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsProductPrice.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //===========================================================================
                ExcelWorksheet wsMem = package.Workbook.Worksheets.Add("会员成长表");
                //取得资料
                DataTable dtMem = GetMemberGrowthDataTable();

                //将datatable资料塞进sheet中
                wsMem.Cells["A1"].LoadFromDataTable(dtMem, true);

                //自动调整大小
                wsMem.Cells[wsMem.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsMem.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //========================================================================
                ExcelWorksheet wsPD = package.Workbook.Worksheets.Add("产品相关资料");
                //取得资料
                DataTable dtpd = GetALLProductPriceDataTable();

                //将datatable资料塞进sheet中
                wsPD.Cells["A1"].LoadFromDataTable(dtpd, true);

                //自动调整大小
                wsPD.Cells[wsPD.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsPD.Cells["A1:D1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //==============================================================================
                ExcelWorksheet wspetcoin = package.Workbook.Worksheets.Add("会员petcoin统计表");
                //取得资料
                DataTable dtptcoin = GetPetCoinDataTable();

                //将datatable资料塞进sheet中
                wspetcoin.Cells["A1"].LoadFromDataTable(dtptcoin, true);

                //自动调整大小
                wspetcoin.Cells[wspetcoin.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wspetcoin.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //=================================================================================
                ExcelWorksheet wstopproduct = package.Workbook.Worksheets.Add("商品销售排行榜");
                //取得资料
                DataTable dttopproduct = GetTopProductDataTable();

                //将datatable资料塞进sheet中
                wstopproduct.Cells["A1"].LoadFromDataTable(dttopproduct, true);

                //自动调整大小
                wstopproduct.Cells[wstopproduct.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wstopproduct.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //========================================
                var stream = new MemoryStream();
                //存档
                package.SaveAs(stream);

                string fileName = DateTime.Now.ToShortDateString() + ".xlsx";

                string contentType = "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet";

                stream.Position = 0;

                return File(stream, contentType, fileName);
            }
        }

        public ActionResult ExportChart()
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                int Man = _dbContext.tMembers.Where(x => x.fGender == "男").Count();
                int Woman = _dbContext.tMembers.Where(x => x.fGender == "女").Count();

                ExcelWorksheet wsPClass = excelPackage.Workbook.Worksheets.Add("会员宠物类别比例图");

                DataTable dtpc = GetPetClassDataTable();
                wsPClass.Cells["A1"].LoadFromDataTable(dtpc, true);

                //自动调整大小
                wsPClass.Cells[wsPClass.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsPClass.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //新增圆饼图
                ExcelPieChart ChartPetClass = (ExcelPieChart)wsPClass.Drawings.AddChart("会员宠物类别比例图", eChartType.Pie3D);
                ChartPetClass.Title.Text = "会员宠物类别比例图";//图表名字
                //圆饼图资料范围
                ChartPetClass.Series.Add(ExcelRange.GetAddress(2, 2, 3, 2), ExcelRange.GetAddress(2, 1, 3, 1));
                //图例
                ChartPetClass.Legend.Position = eLegendPosition.Bottom;
                //是否秀%数
                ChartPetClass.DataLabel.ShowPercent = true;

                ChartPetClass.SetSize(300, 400);
                ChartPetClass.SetPosition(3, 0, 2, 0);
                //==============================================================================
                ExcelWorksheet wsDogBreed = excelPackage.Workbook.Worksheets.Add("会员养狗品种分布图");

                DataTable dtdb = GetDogBreedDataTable();
                wsDogBreed.Cells["A1"].LoadFromDataTable(dtdb, true);

                //自动调整大小
                wsDogBreed.Cells[wsDogBreed.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsDogBreed.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //新增圆饼图
                ExcelPieChart ChartDogBreed = (ExcelPieChart)wsDogBreed.Drawings.AddChart("会员养狗品种分布图", eChartType.Pie3D);
                ChartDogBreed.Title.Text = "会员养狗品种分布图";//图表名字
                //圆饼图资料范围
                ChartDogBreed.Series.Add(ExcelRange.GetAddress(2, 2, 17, 2), ExcelRange.GetAddress(2, 1, 17, 1));
                //图例
                ChartDogBreed.Legend.Position = eLegendPosition.Bottom;
                //是否秀%数
                ChartDogBreed.DataLabel.ShowPercent = true;

                ChartDogBreed.SetSize(300, 400);
                ChartDogBreed.SetPosition(3, 0, 2, 0);
                //=========================================================================
                ExcelWorksheet wsCatBreed = excelPackage.Workbook.Worksheets.Add("会员养猫品种分布图");

                DataTable dtcb = GetCatBreedDataTable();
                wsCatBreed.Cells["A1"].LoadFromDataTable(dtcb, true);

                //自动调整大小
                wsCatBreed.Cells[wsCatBreed.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsCatBreed.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }
                //新增圆饼图
                ExcelPieChart ChartCatBreed = (ExcelPieChart)wsCatBreed.Drawings.AddChart("会员养猫品种分布图", eChartType.Pie3D);
                ChartCatBreed.Title.Text = "会员养猫品种分布图";//图表名字
                //圆饼图资料范围
                ChartCatBreed.Series.Add(ExcelRange.GetAddress(2, 2, 11, 2), ExcelRange.GetAddress(2, 1, 11, 1));
                //图例
                ChartCatBreed.Legend.Position = eLegendPosition.Bottom;
                //是否秀%数
                ChartCatBreed.DataLabel.ShowPercent = true;

                ChartCatBreed.SetSize(300, 400);
                ChartCatBreed.SetPosition(3, 0, 2, 0);

                //==============================================================================

                //新增工作表
                ExcelWorksheet wsGender = excelPackage.Workbook.Worksheets.Add("男女分布图");
                //加入资料
                wsGender.Cells[1, 1].Value = "男";
                wsGender.Cells[1, 2].Value = "女";
                wsGender.Cells[2, 1].Value = Man;
                wsGender.Cells[2, 2].Value = Woman;
                //新增圆饼图
                ExcelPieChart ChartGender = (ExcelPieChart)wsGender.Drawings.AddChart("会员男女分布图", eChartType.Pie3D);
                ChartGender.Title.Text = "会员男女分布图";//图表名字
                //圆饼图资料范围
                ChartGender.Series.Add(ExcelRange.GetAddress(2, 1, 2, 2), ExcelRange.GetAddress(1, 1, 1, 2));
                //图例
                ChartGender.Legend.Position = eLegendPosition.Bottom;
                //是否秀%数
                ChartGender.DataLabel.ShowPercent = true;

                ChartGender.SetSize(300, 400);
                ChartGender.SetPosition(3, 0, 2, 0);
                //==============================================================================

                ExcelWorksheet wsCity = excelPackage.Workbook.Worksheets.Add("会员直辖市分布图");

                wsCity.Cells[1, 1].Value = "台北市";
                wsCity.Cells[1, 2].Value = "新北市";
                wsCity.Cells[1, 3].Value = "桃园市";
                wsCity.Cells[1, 4].Value = "台中市";
                wsCity.Cells[1, 5].Value = "台南市";
                wsCity.Cells[1, 6].Value = "高雄市";

                int TPEMEM = _dbContext.tMembers.Where(x => x.fCityID == 3).Count();
                int NTMEM = _dbContext.tMembers.Where(x => x.fCityID == 4).Count();
                int TYMEM = _dbContext.tMembers.Where(x => x.fCityID == 6).Count();
                int TCMEM = _dbContext.tMembers.Where(x => x.fCityID == 11).Count();
                int TNMEM = _dbContext.tMembers.Where(x => x.fCityID == 15).Count();
                int KSHMEM = _dbContext.tMembers.Where(x => x.fCityID == 16).Count();

                wsCity.Cells[2, 1].Value = TPEMEM;
                wsCity.Cells[2, 2].Value = NTMEM;
                wsCity.Cells[2, 3].Value = TYMEM;
                wsCity.Cells[2, 4].Value = TCMEM;
                wsCity.Cells[2, 5].Value = TNMEM;
                wsCity.Cells[2, 6].Value = KSHMEM;

                //新增圆饼图
                ExcelBarChart Chart6Cities = (ExcelBarChart)wsCity.Drawings.AddChart("会员直辖市分布图", eChartType.BarClustered);
                Chart6Cities.Title.Text = "会员直辖市分布图";//图表名字
                //圆饼图资料范围
                var o = Chart6Cities.Series.Add(ExcelRange.GetAddress(2, 1, 2, 6), ExcelRange.GetAddress(1, 1, 1, 6));
                //图例
                Chart6Cities.Legend.Position = eLegendPosition.Bottom;
                Chart6Cities.XAxis.Title.Text = "6大直辖市";
                Chart6Cities.YAxis.Title.Text = "会员人数";
                o.Header = "会员人数";//bar数值的值
                //是否秀%数
                Chart6Cities.DataLabel.ShowValue = true;

                Chart6Cities.SetSize(300, 400);
                Chart6Cities.SetPosition(3, 0, 2, 0);

                //================================================

                ExcelWorksheet wsMem = excelPackage.Workbook.Worksheets.Add("会员人数成长图");
                //取得资料
                DataTable dtMem = GetMemberGrowthDataTable();

                //将datatable资料塞进sheet中
                wsMem.Cells["A1"].LoadFromDataTable(dtMem, true);

                //自动调整大小
                wsMem.Cells[wsMem.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsMem.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }

                ExcelBarChart ChartMemGrowth = (ExcelBarChart)wsMem.Drawings.AddChart("会员人数成长图", eChartType.BarClustered);
                ChartMemGrowth.Title.Text = "会员人数成长图";//图表名字
                //圆饼图资料范围
                var chmg = ChartMemGrowth.Series.Add(ExcelRange.GetAddress(2, 2, 7, 2), ExcelRange.GetAddress(2, 1, 7, 1));
                //图例
                ChartMemGrowth.Legend.Position = eLegendPosition.Bottom;
                ChartMemGrowth.XAxis.Title.Text = "年份";
                ChartMemGrowth.YAxis.Title.Text = "会员人数";
                chmg.Header = "会员人数";//bar数值的值
                //是否秀%数
                ChartMemGrowth.DataLabel.ShowValue = true;

                ChartMemGrowth.SetSize(300, 400);
                ChartMemGrowth.SetPosition(3, 0, 2, 0);
                //=======================================================================================

                ExcelWorksheet wsProductPrice = excelPackage.Workbook.Worksheets.Add("产品种类平均销售价格");

                DataTable dtpp = GetProductPriceDataTable();
                wsProductPrice.Cells["A1"].LoadFromDataTable(dtpp, true);

                //自动调整大小
                wsProductPrice.Cells[wsProductPrice.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wsProductPrice.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }

                ExcelBarChart ChartProductPrice = (ExcelBarChart)wsProductPrice.Drawings.AddChart("产品种类平均销售价格", eChartType.BarClustered);
                ChartProductPrice.Title.Text = "产品种类平均销售价格";//图表名字
                //圆饼图资料范围
                var chpp = ChartProductPrice.Series.Add(ExcelRange.GetAddress(2, 2, 9, 2), ExcelRange.GetAddress(2, 1, 9, 1));
                //图例
                ChartProductPrice.Legend.Position = eLegendPosition.Bottom;
                ChartProductPrice.XAxis.Title.Text = "产品名称";
                ChartProductPrice.YAxis.Title.Text = "产品平均价格";
                chpp.Header = "产品平均价格";//bar数值的值
                //是否秀%数
                ChartProductPrice.DataLabel.ShowValue = true;

                ChartProductPrice.SetSize(300, 400);
                ChartProductPrice.SetPosition(3, 0, 2, 0);
                //============================================================================================
                ExcelWorksheet wstopproduct = excelPackage.Workbook.Worksheets.Add("商品销售排行榜");
                //取得资料
                DataTable dttopproduct = GetTopProductDataTable();

                //将datatable资料塞进sheet中
                wstopproduct.Cells["A1"].LoadFromDataTable(dttopproduct, true);

                //自动调整大小
                wstopproduct.Cells[wstopproduct.Dimension.Address].AutoFitColumns();
                //设定EXCEL样式
                using (ExcelRange rng = wstopproduct.Cells["A1:B1"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    rng.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                    rng.Style.Font.Color.SetColor(Color.White);
                    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.General;
                }

                ExcelBarChart ChartTopProduct = (ExcelBarChart)wstopproduct.Drawings.AddChart("商品销售排行榜", eChartType.BarClustered);
                ChartTopProduct.Title.Text = "商品销售排行榜";//图表名字
                //圆饼图资料范围
                var chtop = ChartTopProduct.Series.Add(ExcelRange.GetAddress(2, 2, 9, 2), ExcelRange.GetAddress(2, 1, 9, 1));
                //图例
                ChartTopProduct.Legend.Position = eLegendPosition.Bottom;
                ChartTopProduct.XAxis.Title.Text = "产品名称";
                ChartTopProduct.YAxis.Title.Text = "产品数量";
                chpp.Header = "产品数量";//bar数值的值
                //是否秀%数
                ChartTopProduct.DataLabel.ShowValue = true;

                ChartTopProduct.SetSize(600, 800);
                ChartTopProduct.SetPosition(3, 0, 2, 0);

                //===================
                var stream = new MemoryStream();
                //存档
                excelPackage.SaveAs(stream);

                string fileName = DateTime.Now.ToShortDateString() + "Chart" + ".xlsx";

                string contentType = "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet";

                stream.Position = 0;
                return File(stream, contentType, fileName);
            }
        }
    }
}