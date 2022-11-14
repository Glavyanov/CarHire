namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Mapping table between discount and vehicle")]
    public class VehicleDiscount
    {
        [ForeignKey(nameof(Vehicle))]
        [Comment("Foreign key")]
        public Guid VehicleId { get; set; }

        [Required]
        [Comment("Navigation property for vehicle")]
        public virtual Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(Discount))]
        [Comment("Foreign key")]
        public Guid DiscountId { get; set; }

        [Required]
        [Comment("Navigation property for discount")]
        public virtual Discount Discount { get; set; } = null!;
    }
}
