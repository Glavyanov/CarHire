namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarHire.Infrastructure.Data.Entities;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUsers());
        }

        private static List<ApplicationUser> SeedUsers()
        {
            List<ApplicationUser> users = new();
            PasswordHasher<ApplicationUser> hasher = new();

            ApplicationUser user = new()
            {
                Id = "44569627-988b-4096-8397-48cae1a68157",
                UserName = "John@mail.com",
                NormalizedUserName = "JOHN@MAIL.COM",
                Email = "John@mail.com",
                NormalizedEmail = "JOHN@MAIL.COM",
                FirstName = "John",
                LastName = "Doe",
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");

            users.Add(user);

            user = new()
            {
                Id = "27fba6ae-8175-4484-9b0d-917d6b32c851",
                UserName = "Jane@mail.com",
                NormalizedUserName = "JANE@MAIL.COM",
                Email = "Jane@mail.com",
                NormalizedEmail = "JANE@MAIL.COM",
                FirstName = "Jane",
                LastName = "Doe",
            };
            user.PasswordHash = hasher.HashPassword(user, "654321");

            users.Add(user);

            return users;
        }
    }
}
