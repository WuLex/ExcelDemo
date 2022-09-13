using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tDiscussionClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tDiscussionClass()
        {
            this.tDiscussions = new HashSet<tDiscussion>();
        }
        [Key]
        public int fDiscussionClassID { get; set; }

        public string fName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDiscussion> tDiscussions { get; set; }
    }
}