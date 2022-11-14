namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.DiscountConstants;


    [Comment("Discounts for vehicles")]
    public class Discount
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; init; }

        [Comment("Size of discount")]
        public int DiscountSize { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Name of discount")]
        public string Name { get; set; } = null!;

        [Comment("Expiration of discount")]
        public DateTime ExpireOn { get; set; }

        [Comment("Vehicles with discounts")]
        public virtual ICollection<VehicleDiscount> VehicleDiscounts { get; set; } = new HashSet<VehicleDiscount>();
    }
}
