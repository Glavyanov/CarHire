namespace CarHire.Infrastructure.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CarHire.Infrastructure.Data.Entities;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private static List<Category> SeedCategories()
        {
            List<Category> categories = new();
            Category category = new()
            {
                Id = 1,
                Name = "Passenger"
            };
            categories.Add(category);

            category = new()
            {
                Id = 2,
                Name = "Light comercial"
            };
            categories.Add(category);

            category = new()
            {
                Id = 3,
                Name = "Heavy-Duty"
            };
            categories.Add(category);

            category = new()
            {
                Id = 4,
                Name = "Bus"
            };
            categories.Add(category);

            return categories;
        }

    }
}
