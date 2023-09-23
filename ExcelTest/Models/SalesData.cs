using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.Models
{
    public class SalesData
    {
        public string Date { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public List<LastMonthSale> LastMonthSales { get; set; }
        public List<CurrentMonthSale> CurrentMonthSales { get; set; }
        public List<CurrentMonthBalance> CurrentMonthBalance { get; set; }
    }



}
