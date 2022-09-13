using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tAuthority
    {
        [Key]
        public int fAuthorityID { get; set; }

        public string fName { get; set; }
    }
}