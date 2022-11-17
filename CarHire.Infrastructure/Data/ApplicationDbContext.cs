namespace CarHire.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using CarHire.Infrastructure.Data.Entities;
    using static ValidationConstants.ApplicationUserConstants;
    using CarHire.Infrastructure.Data.Configuration;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Discount> Discounts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Renter> Renters { get; set; } = null!;

        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        public DbSet<VehicleDiscount> VehiclesDiscounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleDiscount>()
                .HasKey(k => new { k.VehicleId, k.DiscountId });

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new UserClaimsConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new RenterConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(p => p.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(p => p.NormalizedUserName)
                .HasMaxLength(UserNameMaxLength);

            builder.Entity<ApplicationUser>()
                .Property(p => p.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(p => p.NormalizedEmail)
                .HasMaxLength(EmailMaxLength);
        }
    }
}