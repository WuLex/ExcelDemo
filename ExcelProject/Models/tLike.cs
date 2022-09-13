using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tLike
    {
        [Key]
        public int fLikeID { get; set; }

        public Nullable<int> fArticleID { get; set; }

        public Nullable<int> fMemberID { get; set; }

        public virtual tDiscussion tDiscussion { get; set; }

        public virtual tMember tMember { get; set; }
    }
}