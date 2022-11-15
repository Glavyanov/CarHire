namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static ValidationConstants.ClaimsConstants;

    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.HasData(SeedClaims());
        }

        private List<IdentityUserClaim<string>> SeedClaims()
        {
            var usersClaims = new List<IdentityUserClaim<string>>();

            var userClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                UserId = "44569627-988b-4096-8397-48cae1a68157",
                ClaimType = FirstName,
                ClaimValue = "John"
            };
            usersClaims.Add(userClaim);

            userClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                UserId = "27fba6ae-8175-4484-9b0d-917d6b32c851",
                ClaimType = FirstName,
                ClaimValue = "Jane"
            };
            usersClaims.Add(userClaim);

            return usersClaims;
        }
    }
}
