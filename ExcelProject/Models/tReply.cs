using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tReply
    {
        [Key]
        public int fReplyID { get; set; }

        public int fArticleID { get; set; }

        public int fMemberID { get; set; }

        public string fContext { get; set; }
    }
}