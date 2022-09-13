using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPurchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPurchase()
        {
            this.tPurchase_Detials = new HashSet<tPurchase_Detials>();
        }
        [Key]
        public int fPurchaseID { get; set; }

        public System.DateTime fPurchaseDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPurchase_Detials> tPurchase_Detials { get; set; }
    }
}