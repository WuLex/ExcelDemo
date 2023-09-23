using Microsoft.EntityFrameworkCore;

namespace ExcelProject.Models
{
    public class ChipDbDbContext : DbContext
    {
        public DbSet<SalesData> SalesData { get; set; }

        public ChipDbDbContext(DbContextOptions<ChipDbDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 使用 Fluent API 配置表名映射
            modelBuilder.Entity<SalesData>().ToTable("SalesData");
        }
    }
}
