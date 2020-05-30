using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Viking.Entities;

namespace Viking.Contexts
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<FilterDisplayColumn> FilterDisplayColumns { get; set; }
        public DbSet<FilterSortColumn> FilterSortColumns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .DefaultConfigure(c => new { c.Name });

            builder.Entity<PurchaseOrder>()
                .DefaultConfigure(p => new { p.Company, p.PONum });

            builder.Entity<PurchaseOrderLine>()
                .DefaultConfigure(p => new { p.Company, p.PONum, p.LineNum })
                .HasOne(p => p.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderLines)
                .HasForeignKey(p => new { p.Company, p.PONum });

            builder.Entity<Filter>()
                .ToTable(nameof(Filter))
                .DefaultConfigure(f => new { f.Company, f.TableName, f.DisplayName });

            builder.Entity<FilterDisplayColumn>()
                .ToTable(nameof(FilterDisplayColumn))
                .HasKey(f => new { f.Company, f.TableName, f.DisplayName, f.ColumnPath });

            builder.Entity<FilterDisplayColumn>()
                .HasOne(f => f.Filter)
                .WithMany(f => f.FilterDisplayColumns)
                .HasForeignKey(f => new { f.Company, f.TableName, f.DisplayName });

            builder.Entity<FilterSortColumn>()
                .ToTable(nameof(FilterSortColumn))
                .HasKey(f => new { f.Company, f.TableName, f.DisplayName, f.ColumnPath });

            builder.Entity<FilterSortColumn>()
                .HasOne(f => f.Filter)
                .WithMany(f => f.FilterSortColumns)
                .HasForeignKey(f => new { f.Company, f.TableName, f.DisplayName });

            builder.Entity<Interaction>()
                .DefaultConfigure();
        }
    }
}
