namespace CarHire.Infrastructure.Data.Configuration
{
    using CarHire.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RenterConfiguration : IEntityTypeConfiguration<Renter>
    {
        public void Configure(EntityTypeBuilder<Renter> builder)
        {
            builder.HasData(new Renter()
            {
                Id = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                ApplicationUserId = "27fba6ae-8175-4484-9b0d-917d6b32c851",
                RenterDiscount = 15,
                TotalValue = 0,
                DrivingLicenseNumber = "Jane888888Doe",
                RegisteredOn = DateTime.Now,

            });
        }
    }
}
