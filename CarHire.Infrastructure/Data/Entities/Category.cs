namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.CategoryConstants;

    [Comment("Vehicle category")]
    public class Category
    {
        [Key]
        [Comment("Primary key")]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = null!;

        [Comment("Vehicles in given category")]
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
    }
}
