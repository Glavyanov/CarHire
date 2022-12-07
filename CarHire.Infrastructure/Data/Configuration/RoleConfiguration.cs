namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole()
            {
                Id = "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            },
            new IdentityRole()
            {
                Id = "fc4fdb35-719a-4ac2-8041-2e5034d2bae6",
                Name = "Manager",
                NormalizedName = "MANAGER".ToUpper()
            });
        }
    }
}
