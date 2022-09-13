using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tBreed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tBreed()
        {
            this.tFoundPets = new HashSet<tFoundPet>();

            this.tPetMembers = new HashSet<tPetMember>();
        }

        [Key]
        public int fBreedID { get; set; }

        public string fName { get; set; }

        public int fPetClassID { get; set; }

        public string fPic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFoundPet> tFoundPets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPetMember> tPetMembers { get; set; }

        public virtual tPetClass tPetClass { get; set; }
    }
}