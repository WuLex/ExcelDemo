using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tAdoptMessage
    {
        [Key]
        public int fMessageID { get; set; }

        public int fPetID { get; set; }

        public int fMemberID { get; set; }

        public string fContent { get; set; }

        public virtual tMember tMember { get; set; }

        public virtual tPetMember tPetMember { get; set; }
    }
}