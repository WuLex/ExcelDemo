namespace ExcelProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tCategory()
        {
            this.tProducts = new HashSet<tProduct>();
        }
        [Key]
        public int fCategoryID { get; set; }

        public string fName { get; set; }

        public string fDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tProduct> tProducts { get; set; }
    }
}