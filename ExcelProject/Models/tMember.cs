using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelProject.Models
{
    public partial class tMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tMember()
        {
            this.tAdoptMessages = new HashSet<tAdoptMessage>();

            this.tComments = new HashSet<tComment>();

            this.tDiscussions = new HashSet<tDiscussion>();

            this.tFavorites = new HashSet<tFavorite>();

            this.tFoundPets = new HashSet<tFoundPet>();

            this.tLikes = new HashSet<tLike>();

            this.tOrders = new HashSet<tOrder>();

            this.tPetMembers = new HashSet<tPetMember>();

            this.tReports = new HashSet<tReport>();

            this.tShoppingCarts = new HashSet<tShoppingCart>();
        }
        [Key]
        public int fMemberID { get; set; }

        public string fName { get; set; }

        public string fGender { get; set; }

        public string fIDCardNumber { get; set; }

        public string fNickName { get; set; }

        public string fAccount { get; set; }

        public string fPassword { get; set; }

        public System.DateTime fBirthDate { get; set; }

        public string fEnconomicStatus { get; set; }

        public string fPhone { get; set; }

        public string fEMail { get; set; }

        public Nullable<System.DateTime> fRegisterDate { get; set; }

        public Nullable<int> fLogInWayID { get; set; }

        public string fIcon { get; set; }

        public Nullable<System.DateTime> fRecentLogInDate { get; set; }

        public int fCityID { get; set; }

        public int fRegionID { get; set; }

        public string fAddressDetail { get; set; }

        public Nullable<decimal> fPetCoin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tAdoptMessage> tAdoptMessages { get; set; }

        public virtual tCity tCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tComment> tComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tDiscussion> tDiscussions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFavorite> tFavorites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFoundPet> tFoundPets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tLike> tLikes { get; set; }

        //[InverseProperty("tMembers")]
        public virtual tRegion tRegion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tOrder> tOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPetMember> tPetMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tReport> tReports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tShoppingCart> tShoppingCarts { get; set; }
    }
}