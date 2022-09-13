namespace ExcelProject.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tCategory
    {
        public tCategory()
        {
            this.tProducts = new HashSet<tProduct>();
        }
        [Key]
        public int fCategoryID { get; set; }

        public string fName { get; set; }

        public string fDescription { get; set; }

        public virtual ICollection<tProduct> tProducts { get; set; }
    }
}