using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tPetMember
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tPetMember()
    {

        this.tAdoptMessages = new HashSet<tAdoptMessage>();

        this.tLostPets = new HashSet<tLostPet>();

    }
    [Key] 

    public int fPetID { get; set; }

    public int fMemberID { get; set; }

    public string fPetName { get; set; }

    public string fGender { get; set; }

    public int fPetClassID { get; set; }

    public int fBreedID { get; set; }

    public int fCityID { get; set; }

    public int fRegionID { get; set; }

    public string fPetPic { get; set; }

    public string fChipID { get; set; }

    public string fCollar { get; set; }

    public string fSkin { get; set; }

    public string fStatus { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tAdoptMessage> tAdoptMessages { get; set; }

    public virtual tBreed tBreed { get; set; }

    public virtual tCity tCity { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tLostPet> tLostPets { get; set; }

    public virtual tMember tMember { get; set; }

    public virtual tPetClass tPetClass { get; set; }

    public virtual tRegion tRegion { get; set; }

}

}
