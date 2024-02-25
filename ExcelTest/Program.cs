// 创建一个新的Excel包
using ExcelTest.Common;
using ExcelTest.Models;

#region 示例一
////var data = new[]
////{
////    new { Date = "2023-09-01", Unit = "单位1", Price = 10.5, LastMonthSales = new[] { new { ProductCode = "ABC", Amount = 100 } }, CurrentMonthSales = new[] { new { ProductCode = "DEF", Amount = 200 } }, CurrentMonthBalance = new[] { new { ProductCode = "GHI", Amount = 50 } } },
////    new { Date = "2023-09-02", Unit = "单位2", Price = 11.0, LastMonthSales = new[] { new { ProductCode = "XYZ", Amount = 150 } }, CurrentMonthSales = new[] { new { ProductCode = "LMN", Amount = 300 } }, CurrentMonthBalance = new[] { new { ProductCode = "PQR", Amount = 75 } } },
////    new { Date = "2023-09-03", Unit = "单位3", Price = 9.8, LastMonthSales = new[] { new { ProductCode = "123", Amount = 75 } }, CurrentMonthSales = new[] { new { ProductCode = "456", Amount = 250 } }, CurrentMonthBalance = new[] { new { ProductCode = "789", Amount = 80 } } },
////    new { Date = "2023-09-04", Unit = "单位4", Price = 12.2, LastMonthSales = new[] { new { ProductCode = "JKL", Amount = 90 } }, CurrentMonthSales = new[] { new { ProductCode = "MNO", Amount = 180 } }, CurrentMonthBalance = new[] { new { ProductCode = "STU", Amount = 45 } } },
////    new { Date = "2023-09-05", Unit = "单位5", Price = 8.5, LastMonthSales = new[] { new { ProductCode = "EFG", Amount = 120 } }, CurrentMonthSales = new[] { new { ProductCode = "HIJ", Amount = 220 } }, CurrentMonthBalance = new[] { new { ProductCode = "VWX", Amount = 60 } } },
////    new { Date = "2023-09-06", Unit = "单位6", Price = 11.8, LastMonthSales = new[] { new { ProductCode = "456", Amount = 80 } }, CurrentMonthSales = new[] { new { ProductCode = "LMN", Amount = 170 } }, CurrentMonthBalance = new[] { new { ProductCode = "PQR", Amount = 55 } } },
////    new { Date = "2023-09-07", Unit = "单位7", Price = 9.9, LastMonthSales = new[] { new { ProductCode = "XYZ", Amount = 110 } }, CurrentMonthSales = new[] { new { ProductCode = "JKL", Amount = 160 } }, CurrentMonthBalance = new[] { new { ProductCode = "MNO", Amount = 70 } } },
////    new { Date = "2023-09-08", Unit = "单位8", Price = 10.0, LastMonthSales = new[] { new { ProductCode = "ABC", Amount = 130 } }, CurrentMonthSales = new[] { new { ProductCode = "GHI", Amount = 240 } }, CurrentMonthBalance = new[] { new { ProductCode = "DEF", Amount = 30 } } },
////    new { Date = "2023-09-09", Unit = "单位9", Price = 9.5, LastMonthSales = new[] { new { ProductCode = "123", Amount = 70 } }, CurrentMonthSales = new[] { new { ProductCode = "VWX", Amount = 190 } }, CurrentMonthBalance = new[] { new { ProductCode = "789", Amount = 40 } } },
////    new { Date = "2023-09-10", Unit = "单位10", Price = 11.2, LastMonthSales = new[] { new { ProductCode = "EFG", Amount = 100 } }, CurrentMonthSales = new[] { new { ProductCode = "STU", Amount = 210 } }, CurrentMonthBalance = new[] { new { ProductCode = "HIJ", Amount = 50 } } },
////};
//var data = new List<SalesData>
//{
//    new SalesData
//    {
//        Date = "2023-09-01",
//        Unit = "单位1",
//        Price = 10.5,
//        LastMonthSales = new List<LastMonthSale>
//        {
//            new LastMonthSale { ProductCode = "ABC", Amount = 100 }
//        },
//        CurrentMonthSales = new List<CurrentMonthSale>
//        {
//            new CurrentMonthSale { ProductCode = "DEF", Amount = 200 }
//        },
//        CurrentMonthBalance = new List<CurrentMonthBalance>
//        {
//            new CurrentMonthBalance { ProductCode = "GHI", Amount = 50 }
//        }
//    },
//    new SalesData
//    {
//        Date = "2023-09-02",
//        Unit = "单位2",
//        Price = 11.0,
//        LastMonthSales = new List<LastMonthSale>
//        {
//            new LastMonthSale { ProductCode = "XYZ", Amount = 150 }
//        },
//        CurrentMonthSales = new List<CurrentMonthSale>
//        {
//            new CurrentMonthSale { ProductCode = "LMN", Amount = 300 }
//        },
//        CurrentMonthBalance = new List<CurrentMonthBalance>
//        {
//            new CurrentMonthBalance { ProductCode = "PQR", Amount = 75 }
//        }
//    },
//    new SalesData
//    {
//        Date = "2023-09-03",
//        Unit = "单位3",
//        Price = 9.8,
//        LastMonthSales = new List<LastMonthSale>
//        {
//            new LastMonthSale { ProductCode = "123", Amount = 75 }
//        },
//        CurrentMonthSales = new List<CurrentMonthSale>
//        {
//            new CurrentMonthSale { ProductCode = "456", Amount = 250 }
//        },
//        CurrentMonthBalance = new List<CurrentMonthBalance>
//        {
//            new CurrentMonthBalance { ProductCode = "789", Amount = 80 }
//        }
//    },
//    new SalesData
//    {
//        Date = "2023-09-04",
//        Unit = "单位4",
//        Price = 12.2,
//        LastMonthSales = new List<LastMonthSale>
//        {
//            new LastMonthSale { ProductCode = "JKL", Amount = 90 }
//        },
//        CurrentMonthSales = new List<CurrentMonthSale>
//        {
//            new CurrentMonthSale { ProductCode = "MNO", Amount = 180 }
//        },
//        CurrentMonthBalance = new List<CurrentMonthBalance>
//        {
//            new CurrentMonthBalance { ProductCode = "STU", Amount = 45 }
//        }
//    },
//    new SalesData
//    {
//        Date = "2023-09-05",
//        Unit = "单位5",
//        Price = 8.5,
//        LastMonthSales = new List<LastMonthSale>
//        {
//            new LastMonthSale { ProductCode = "EFG", Amount = 120 }
//        },
//        CurrentMonthSales = new List<CurrentMonthSale>
//        {
//            new CurrentMonthSale { ProductCode = "HIJ", Amount = 220 }
//        },
//        CurrentMonthBalance = new List<CurrentMonthBalance>
//        {
//            new CurrentMonthBalance { ProductCode = "VWX", Amount = 60 }
//        }
//    },
//    // 只需添加更多数据...
//};

//SalesReportHelper.GenerateSalesReport("SalesReport.xlsx", data);
#endregion

#region 示例二
//MergeHelper.ExportData();
#endregion

#region 示例三
//ComplexDataHelper.ExportData();
#endregion

#region 示例四
//MergeHelper.ExportData();
#endregion


#region 示例五:EXCEL转html的table代码
ExcelToHtmlHepler.ExportTableCode();
#endregion