using Microsoft.EntityFrameworkCore;

namespace ExcelProject.Models
{
    public class NewPetContext : DbContext
    {
        public NewPetContext(DbContextOptions<NewPetContext> options) : base(options)
        {
        }

        //public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        public virtual DbSet<tActivity> tActivities { get; set; }

        public virtual DbSet<tAdoptMessage> tAdoptMessages { get; set; }

        public virtual DbSet<tAuthority> tAuthorities { get; set; }

        public virtual DbSet<tBreed> tBreeds { get; set; }

        public virtual DbSet<tCategory> tCategories { get; set; }

        public virtual DbSet<tCity> tCities { get; set; }

        public virtual DbSet<tComment> tComments { get; set; }

        public virtual DbSet<tCurse> tCurses { get; set; }

        public virtual DbSet<tDiscussion> tDiscussions { get; set; }

        public virtual DbSet<tDiscussionClass> tDiscussionClasses { get; set; }

        public virtual DbSet<tEmployee> tEmployees { get; set; }

        public virtual DbSet<tFavorite> tFavorites { get; set; }

        public virtual DbSet<tFoundPet> tFoundPets { get; set; }

        public virtual DbSet<tLike> tLikes { get; set; }

        public virtual DbSet<tLogInWay> tLogInWays { get; set; }

        public virtual DbSet<tLostPet> tLostPets { get; set; }

        public virtual DbSet<tMember> tMembers { get; set; }

        public virtual DbSet<tOrder_Detail> tOrder_Detail { get; set; }

        public virtual DbSet<tOrder> tOrders { get; set; }

        public virtual DbSet<tPayWay> tPayWays { get; set; }

        public virtual DbSet<tPetClass> tPetClasses { get; set; }

        public virtual DbSet<tPetMember> tPetMembers { get; set; }

        public virtual DbSet<tProduct> tProducts { get; set; }

        public virtual DbSet<tPurchase> tPurchases { get; set; }

        public virtual DbSet<tPurchase_Detials> tPurchase_Detials { get; set; }

        public virtual DbSet<tPurchaseShoppingCart> tPurchaseShoppingCarts { get; set; }

        public virtual DbSet<tRegion> tRegions { get; set; }

        public virtual DbSet<tReply> tReplies { get; set; }

        public virtual DbSet<tReport> tReports { get; set; }

        public virtual DbSet<tShipVia> tShipVias { get; set; }

        public virtual DbSet<tShoppingCart> tShoppingCarts { get; set; }

        public virtual DbSet<tSupplier> tSuppliers { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
