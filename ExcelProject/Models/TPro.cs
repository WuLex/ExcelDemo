using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public class TPro
    {
        [Key]
        public int fProductID { get; set; }
        public string fName { get; set; }
        public string fPic { get; set; }
        public string fCategoryName { get; set; }
        public double fUnitPrice { get; set; }

        public int fUnitInStock { get; set; }

        public string fSupplierName { get; set; }

        public virtual tCategory tCategory { get; set; }

        public virtual tSupplier tSupplier { get; set; }
    }
}