using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPurchaseShoppingCart
    {
        [Key]
        public int fCartID { get; set; }

        public int fProductID { get; set; }

        public int fSupplierID { get; set; }

        public decimal fUnitPrice { get; set; }

        public int fQuantity { get; set; }

        public string fPic { get; set; }

        public virtual tProduct tProduct { get; set; }

        public virtual tSupplier tSupplier { get; set; }
    }
}