using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPetClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPetClass()
        {
            this.tBreeds = new HashSet<tBreed>();

            this.tFoundPets = new HashSet<tFoundPet>();

            this.tPetMembers = new HashSet<tPetMember>();
        }
        [Key]
        public int fPetClassID { get; set; }

        public string fName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tBreed> tBreeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFoundPet> tFoundPets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPetMember> tPetMembers { get; set; }
    }
}