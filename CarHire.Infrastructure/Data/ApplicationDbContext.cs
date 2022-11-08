namespace CarHire.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using CarHire.Infrastructure.Data.Entities;
    using static ValidationConstants.ApplicationUserConstants;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(p => p.UserName)
                .HasMaxLength(UserNameMaxLength)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(p => p.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();
        }
    }
}