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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .DefaultConfigure(c => new { c.Name });

            builder.Entity<PurchaseOrder>()
                .DefaultConfigure(p => new { p.Company, p.PONum })
                .HasMany(e => e.PurchaseOrderLines)
                .WithOne(e => e.PurchaseOrder);

            builder.Entity<PurchaseOrderLine>()
                .DefaultConfigure(p => new { p.Company, p.PONum, p.LineNum })
                .HasOne(e => e.PurchaseOrder)
                .WithMany(e => e.PurchaseOrderLines);

            builder.Entity<Interaction>()
                .DefaultConfigure();
                

        }
    }
}
