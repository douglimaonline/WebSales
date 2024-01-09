using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebSales.Models;

namespace WebSales.Data
{
    public class WebSalesContext : DbContext
    {
        public WebSalesContext(DbContextOptions<WebSalesContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecords { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Seller>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
