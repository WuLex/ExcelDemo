using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public class SalesData
    {
        public int ID { get; set; }

        [Required]
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public string Salesperson { get; set; } // 添加销售员属性
    }
}
