using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tOrder()
        {
            this.tOrder_Detail = new HashSet<tOrder_Detail>();
        }
        [Key]
        public int fOrderID { get; set; }

        public int fMemberID { get; set; }

        public Nullable<System.DateTime> fOrderDate { get; set; }

        public Nullable<System.DateTime> fShipOutDate { get; set; }

        public string fReceiverName { get; set; }

        public string fReceiverPhone { get; set; }

        public int fCityID { get; set; }

        public int fRegionID { get; set; }

        public string fAddressDetail { get; set; }

        public string fReceiverMail { get; set; }

        public int fPayWayID { get; set; }

        public string fStatus { get; set; }

        public virtual tCity tCity { get; set; }

        public virtual tMember tMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder_Detail> tOrder_Detail { get; set; }

        public virtual tPayWay tPayWay { get; set; }

        public virtual tRegion tRegion { get; set; }
    }
}