namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static ValidationConstants.RenterConstants;

    [Comment("Application renter")]
    public class Renter
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; init; }

        [ForeignKey(nameof(ApplicationUser))]
        [Comment("Foreign key to ApplicationUser table")]
        public string ApplicationUserId { get; set; } = null!;

        [Required]
        [Comment("Navigation property for ApplicationUser")]
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Comment("Discount of renter")]
        public int RenterDiscount { get; set; }

        [Column(TypeName = "money")]
        [Comment("Value of all orders of renter")]
        public decimal TotalValue { get; set; }

        [Required]
        [MaxLength(DrivingLicenseNumberMaxLength)]
        [Comment("Driving license number of renter")]
        public string DrivingLicenseNumber { get; set; } = null!;

        [Comment("When became a renter")]
        public DateTime RegisteredOn { get; set; }
    }
}
