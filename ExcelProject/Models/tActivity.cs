using System.ComponentModel.DataAnnotations;

namespace ExcelProject.Models
{
    public  class tActivity
    {
        [Key]
        public int fActivityID { get; set; }

        public string fName { get; set; }

        public System.DateTime fEffectiveDate { get; set; }

        public string fContext { get; set; }

        public string fDMPic { get; set; }

        public Nullable<System.DateTime> fClosedDate { get; set; }
    }
}