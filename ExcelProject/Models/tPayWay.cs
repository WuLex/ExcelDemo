using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPayWay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPayWay()
        {
            this.tOrders = new HashSet<tOrder>();
        }
        [Key]
        public int fPayWayID { get; set; }

        public string fName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder> tOrders { get; set; }
    }
}