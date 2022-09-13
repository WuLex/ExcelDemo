using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public class Trep
    {
        [Key]
        public int fReportID { get; set; }
        public string fArticleID { get; set; }
        public string fMemberID { get; set; }
        public string fReportComment { get; set; }

        public virtual tDiscussion tDiscussion { get; set; }
        public virtual tMember tMember { get; set; }
    }
}