using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tSupplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tSupplier()
        {
            this.tProducts = new HashSet<tProduct>();

            this.tPurchase_Detials = new HashSet<tPurchase_Detials>();

            this.tPurchaseShoppingCarts = new HashSet<tPurchaseShoppingCart>();
        }
        [Key]
        public int fSupplierID { get; set; }

        public string fName { get; set; }

        public string fContactName { get; set; }

        public string fAddress { get; set; }

        public int fCityID { get; set; }

        public int fRegionID { get; set; }

        public string fPhone { get; set; }

        public virtual tCity tCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tProduct> tProducts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchase_Detials> tPurchase_Detials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchaseShoppingCart> tPurchaseShoppingCarts { get; set; }

        public virtual tRegion tRegion { get; set; }
    }
}