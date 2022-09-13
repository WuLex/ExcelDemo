using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tProduct()
        {
            this.tOrder_Detail = new HashSet<tOrder_Detail>();

            this.tPurchase_Detials = new HashSet<tPurchase_Detials>();

            this.tPurchaseShoppingCarts = new HashSet<tPurchaseShoppingCart>();

            this.tShoppingCarts = new HashSet<tShoppingCart>();
        }
        [Key]
        public int fProductID { get; set; }

        public string fName { get; set; }

        public string fPic { get; set; }

        public int fCategoryID { get; set; }

        public decimal fUnitPrice { get; set; }

        public int fUnitOnOrder { get; set; }

        public int fUnitInStock { get; set; }

        public Nullable<System.DateTime> fOnShelfDate { get; set; }

        public int fSupplierID { get; set; }

        public int fSafeStock { get; set; }

        public string fDescription { get; set; }

        public virtual tCategory tCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder_Detail> tOrder_Detail { get; set; }

        public virtual tSupplier tSupplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchase_Detials> tPurchase_Detials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchaseShoppingCart> tPurchaseShoppingCarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tShoppingCart> tShoppingCarts { get; set; }
    }
}