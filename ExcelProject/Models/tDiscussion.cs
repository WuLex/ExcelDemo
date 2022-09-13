using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tDiscussion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tDiscussion()
        {
            this.tComments = new HashSet<tComment>();

            this.tFavorites = new HashSet<tFavorite>();

            this.tLikes = new HashSet<tLike>();

            this.tReports = new HashSet<tReport>();
        }

        [Key]
        public int fArticleID { get; set; }

        public Nullable<int> fMemberID { get; set; }

        public string fContent { get; set; }

        public int fDiscussionClassID { get; set; }

        public string fTitle { get; set; }

        public Nullable<System.DateTime> fCreateDate { get; set; }

        public string fPicture { get; set; }

        public Nullable<int> fCommenttime { get; set; }

        public Nullable<bool> fReportcheck { get; set; }

        public Nullable<int> fLike { get; set; }

        public Nullable<bool> fLock { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tComment> tComments { get; set; }

        public virtual tDiscussionClass tDiscussionClass { get; set; }

        public virtual tMember tMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFavorite> tFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tLike> tLikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tReport> tReports { get; set; }
    }
}