namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Comment("Customer orders")]
    public class Order
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; init; }

        [ForeignKey(nameof(Vehicle))]
        [Comment("Foreign key for vehicle")]
        public Guid VehicleId { get; set; }

        [Comment("Navigation property for vehicle")]
        public virtual Vehicle Vehicle { get; set; } = null!;

        [ForeignKey(nameof(Renter))]
        [Comment("Foreign key for renter")]
        public Guid RenterId { get; set; }

        [Comment("Navigation property for renter")]
        public virtual Renter Renter { get; set; } = null!;

        [Comment("Allows entry showing")]
        public bool IsDeleted { get; set; }

        [Comment("Order total days")]
        public int TotalDays { get; set; }

        [Column(TypeName = "money")]
        [Comment("Price before discount")]
        public decimal Price { get; set; }

        [Comment("All discounts of renter and vehicle")]
        public int Discount { get; set; }

        [Column(TypeName = "money")]
        [Comment("Price after all discounts")]
        public decimal TotalPriceWithDiscount { get; set; }

        [Comment("Begining of order")]
        public DateTime StartDate { get; set; }

        [Comment("End of order")]
        public DateTime EndDate { get; set; }

    }
}
