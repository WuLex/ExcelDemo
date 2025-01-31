using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tComment
    {
        [Key]
        public int fId { get; set; }

        public Nullable<int> fMemberID { get; set; }

        public string fContent { get; set; }

        public Nullable<System.DateTime> fCreateDate { get; set; }

        public Nullable<int> fArticleID { get; set; }

        public virtual tDiscussion tDiscussion { get; set; }

        public virtual tMember tMember { get; set; }
    }
}