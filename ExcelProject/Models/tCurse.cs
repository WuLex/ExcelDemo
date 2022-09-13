using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tCurse
    {
        [Key]
        public int fCurseID { get; set; }

        public string fName { get; set; }
    }
}