using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tLostPet
    {
        [Key]
        public int fLostID { get; set; }

        public int fPetID { get; set; }

        public string fLostPlace { get; set; }

        public System.DateTime fLostTime { get; set; }

        public Nullable<decimal> fReward { get; set; }

        public string fRemark { get; set; }

        public string fCompareLevel { get; set; }

        public Nullable<System.DateTime> fSignInDate { get; set; }

        public virtual tPetMember tPetMember { get; set; }
    }
}