using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tEmployee
    {
        [Key]
        public int fEmployeeID { get; set; }

        public string fAccount { get; set; }

        public string fPassword { get; set; }
    }
}