using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public partial class tShipVia
    {
        [Key]
        public int fShipViaID { get; set; }

        public string fName { get; set; }
    }
}