using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelProject.Models
{
    public partial class tRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tRegion()
        {
            this.tFoundPets = new HashSet<tFoundPet>();

            this.tMembers = new HashSet<tMember>();

            this.tOrders = new HashSet<tOrder>();

            this.tPetMembers = new HashSet<tPetMember>();

            this.tSuppliers = new HashSet<tSupplier>();
        }
        [Key]
        public int fRegionID { get; set; }

        public string fName { get; set; }

        public int fCityID { get; set; }

        public virtual tCity tCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFoundPet> tFoundPets { get; set; }

        //[InverseProperty("tRegion")]
        public virtual ICollection<tMember> tMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder> tOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPetMember> tPetMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSupplier> tSuppliers { get; set; }
    }
}