using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public class Tfav
    {
        [Key]
        public int fFavoriteID { get; set; }
        public string fMemberID { get; set; }

        public int? fArticleID { get; set; }
        public string fArticleTitle { get; set; }
        public string discussionchange { get; set; }

        public virtual tDiscussion tDiscussion { get; set; }
        public virtual tMember tMember { get; set; }
    }
}