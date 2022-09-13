using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPurchase_Detials
    {
        [Key]
        public int fPurchaseID { get; set; }

        public int fProductID { get; set; }

        public decimal fUnitPrice { get; set; }

        public int fQuantity { get; set; }

        public string fName { get; set; }

        public string fPic { get; set; }

        public int fSupplierID { get; set; }

        public virtual tProduct tProduct { get; set; }

        public virtual tPurchase tPurchase { get; set; }

        public virtual tSupplier tSupplier { get; set; }
    }
}