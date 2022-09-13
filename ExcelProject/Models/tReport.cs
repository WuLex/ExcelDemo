using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tReport
    {
        [Key]
        public int fReportID { get; set; }

        public int fArticleID { get; set; }

        public int fMemberID { get; set; }

        public string fReportComment { get; set; }

        public virtual tDiscussion tDiscussion { get; set; }

        public virtual tMember tMember { get; set; }
    }
}