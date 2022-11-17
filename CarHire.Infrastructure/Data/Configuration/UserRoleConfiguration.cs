namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
             new IdentityUserRole<string>()
             {
                 RoleId = "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                 UserId = "44569627-988b-4096-8397-48cae1a68157"
             });
        }
    }
}
