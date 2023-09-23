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

        //public virtual DbSet<tAuthority> tAuthorities { get; set; }

        public virtual DbSet<tBreed> tBreeds { get; set; }

        public virtual DbSet<tCategory> tCategories { get; set; }

        public virtual DbSet<tCity> tCities { get; set; }

        public virtual DbSet<tComment> tComments { get; set; }

        //public virtual DbSet<tCurse> tCurses { get; set; }

        public virtual DbSet<tDiscussion> tDiscussions { get; set; }

        //public virtual DbSet<tDiscussionClass> tDiscussionClasses { get; set; }

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
            modelBuilder
            .Entity<tMember>()
            .HasOne(e => e.tRegion)
            .WithMany(e => e.tMembers)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
            .Entity<tSupplier>()
            .HasOne(e => e.tRegion)
            .WithMany(e => e.tSuppliers)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
            .Entity<tFoundPet>()
            .HasOne(e => e.tMember)
            .WithMany(e => e.tFoundPets)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
           .Entity<tFoundPet>()
           .HasOne(e => e.tPetClass)
           .WithMany(e => e.tFoundPets)
           .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
      .Entity<tFoundPet>()
      .HasOne(e => e.tRegion)
      .WithMany(e => e.tFoundPets)
      .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
    .Entity<tOrder>()
    .HasOne(e => e.tMember)
    .WithMany(e => e.tOrders)
    .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
 .Entity<tOrder>()
 .HasOne(e => e.tPayWay)
 .WithMany(e => e.tOrders)
 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
.Entity<tOrder>()
.HasOne(e => e.tRegion)
.WithMany(e => e.tOrders)
.OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
.Entity<tPetMember>()
.HasOne(e => e.tMember)
.WithMany(e => e.tPetMembers)
.OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
            .Entity<tPetMember>()
            .HasOne(e => e.tPetClass)
            .WithMany(e => e.tPetMembers)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
           .Entity<tPetMember>()
           .HasOne(e => e.tRegion)
           .WithMany(e => e.tPetMembers)
           .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
          .Entity<tComment>()
          .HasOne(e => e.tDiscussion)
          .WithMany(e => e.tComments)
          .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
          .Entity<tComment>()
          .HasOne(e => e.tMember)
          .WithMany(e => e.tComments)
          .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
   .Entity<tFavorite>()
   .HasOne(e => e.tDiscussion)
   .WithMany(e => e.tFavorites)
   .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
      .Entity<tFavorite>()
      .HasOne(e => e.tMember)
      .WithMany(e => e.tFavorites)
      .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
      .Entity<tLike>()
      .HasOne(e => e.tDiscussion)
      .WithMany(e => e.tLikes)
      .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tLike>()
     .HasOne(e => e.tMember)
     .WithMany(e => e.tLikes)
     .OnDelete(DeleteBehavior.ClientCascade);

            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tReport>()
                 .HasOne(e => e.tDiscussion)
                 .WithMany(e => e.tReports)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tReport>()
     .HasOne(e => e.tMember)
     .WithMany(e => e.tReports)
     .OnDelete(DeleteBehavior.ClientCascade);
            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tAdoptMessage>()
                 .HasOne(e => e.tPetMember)
                 .WithMany(e => e.tAdoptMessages)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tAdoptMessage>()
     .HasOne(e => e.tMember)
     .WithMany(e => e.tAdoptMessages)
     .OnDelete(DeleteBehavior.ClientCascade);

            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tOrder_Detail>()
                 .HasOne(e => e.tOrder)
                 .WithMany(e => e.tOrder_Detail)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tOrder_Detail>()
     .HasOne(e => e.tProduct)
     .WithMany(e => e.tOrder_Detail)
     .OnDelete(DeleteBehavior.ClientCascade);

            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tPurchase_Detials>()
                 .HasOne(e => e.tProduct)
                 .WithMany(e => e.tPurchase_Detials)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tPurchase_Detials>()
     .HasOne(e => e.tPurchase)
     .WithMany(e => e.tPurchase_Detials)
     .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<tPurchase_Detials>()
                .HasOne(e => e.tSupplier)
                .WithMany(e => e.tPurchase_Detials)
                .OnDelete(DeleteBehavior.ClientCascade);

            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tPurchaseShoppingCart>()
                 .HasOne(e => e.tProduct)
                 .WithMany(e => e.tPurchaseShoppingCarts)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tPurchaseShoppingCart>()
     .HasOne(e => e.tSupplier)
     .WithMany(e => e.tPurchaseShoppingCarts)
     .OnDelete(DeleteBehavior.ClientCascade);

            //----------------------------------------------------------------------
            modelBuilder
                 .Entity<tShoppingCart>()
                 .HasOne(e => e.tMember)
                 .WithMany(e => e.tShoppingCarts)
                 .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
     .Entity<tShoppingCart>()
     .HasOne(e => e.tProduct)
     .WithMany(e => e.tShoppingCarts)
     .OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}