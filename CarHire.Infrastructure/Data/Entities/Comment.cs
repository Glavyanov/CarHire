namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static ValidationConstants.CommentConstants;

    [Comment("Comment for vehicle")]
    public class Comment
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; init; }

        [ForeignKey(nameof(Renter))]
        [Comment("Foreign key for renter")]
        public Guid RenterId { get; set; }

        [Comment("Navigation property for renter")]
        public virtual Renter Renter { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        [Comment("Foreign key for vehicle")]
        public Guid VehicleId { get; set; }

        [Comment("Navigation property for vehicle")]
        public virtual Vehicle Vehicle { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Comment of renter for vehicle")]
        public string Description { get; set; } = null!;

        [Comment("Allows entry showing")]
        public bool IsDeleted { get; set; }

        [Comment("Date and time of comment")]
        public DateTime Date { get; set; }
    }
}
