using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tCity
    {
        public tCity()
        {
            this.tFoundPets = new HashSet<tFoundPet>();

            this.tMembers = new HashSet<tMember>();

            this.tOrders = new HashSet<tOrder>();

            this.tPetMembers = new HashSet<tPetMember>();

            this.tRegions = new HashSet<tRegion>();

            this.tSuppliers = new HashSet<tSupplier>();
        }
        [Key]
        public int fCityID { get; set; }

        public string fName { get; set; }

        public virtual ICollection<tFoundPet> tFoundPets { get; set; }

        public virtual ICollection<tMember> tMembers { get; set; }

        public virtual ICollection<tOrder> tOrders { get; set; }

        public virtual ICollection<tPetMember> tPetMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tRegion> tRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tSupplier> tSuppliers { get; set; }
    }
}