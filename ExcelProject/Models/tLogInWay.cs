using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tLogInWay
    {
        [Key]
        public int fLogInWayID { get; set; }

        public string fName { get; set; }

        public string fIcon { get; set; }
    }
}