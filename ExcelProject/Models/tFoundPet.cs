using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tFoundPet
    {
        [Key]
        public int fFoundPetID { get; set; }

        public Nullable<int> fMemberID { get; set; }

        public string fStatus { get; set; }

        public System.DateTime fFoundTime { get; set; }

        public string fGender { get; set; }

        public int fPetClassID { get; set; }

        public int fBreedID { get; set; }

        public string fPetPic { get; set; }

        public string fSkin { get; set; }

        public string fCollar { get; set; }

        public string fChipID { get; set; }

        public int fCityID { get; set; }

        public int fRegionID { get; set; }

        public string fRemark { get; set; }

        public Nullable<System.DateTime> fSignInDate { get; set; }

        public virtual tBreed tBreed { get; set; }

        public virtual tCity tCity { get; set; }

        public virtual tMember tMember { get; set; }

        public virtual tPetClass tPetClass { get; set; }

        public virtual tRegion tRegion { get; set; }
    }
}