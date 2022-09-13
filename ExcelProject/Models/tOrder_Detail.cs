using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tOrder_Detail
    {
        [Key]
        public int fOrderID { get; set; }

        public int fProductID { get; set; }

        public string fName { get; set; }

        public decimal fUnitPrice { get; set; }

        public int fQuantity { get; set; }

        public string fPic { get; set; }

        public virtual tOrder tOrder { get; set; }

        public virtual tProduct tProduct { get; set; }
    }
}