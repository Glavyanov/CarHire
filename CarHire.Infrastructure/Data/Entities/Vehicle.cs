namespace CarHire.Infrastructure.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using CarHire.Infrastructure.Data.Entities.Enums;
    using static ValidationConstants.VehicleConstants;


    [Comment("Vehicle for rent")]
    public class Vehicle
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; init; }

        [Required]
        [MaxLength(MakeMaxLength)]
        [Comment("Vehicle Make")]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        [Comment("Vehicle Model")]
        public string Model { get; set; } = null!;

        [Required]
        [Comment("Allows entry showing")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Indicates whether the vehicle is rented")]
        public bool IsRented{ get; set; }

        [Comment("Year of manufacture")]
        public int Year { get; init; }

        [Comment("Type of transmission")]
        public Transmission Transmission { get; set; }

        [Comment("Availability of air conditioning")]
        public bool AirConditioning { get; set; }

        [Comment("Number of seats")]
        public int Seats { get; set; }

        [Comment("Number of doors")]
        public int Doors { get; set; }

        [Comment("Type of suspension")]
        public Suspension Suspension { get; set; }

        [Comment("Availability of navigation system")]
        public bool NavigationSystem { get; set; }

        [Comment("Vehicle tank capacity")]
        public int? TankCapacity { get; set; }

        [Comment("Vehicle consumption")]
        public double? Consumption { get; set; }

        [Comment("Vehicle fuel type")]
        public Fuel Fuel { get; set; }

        [Comment("Vehicle kilometers")]
        public int Kilometers { get; set; }

        [Comment("Vehicle price for 1 day")]
        [Column(TypeName = "money")]
        public decimal PricePerDay { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Vehicle image")]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        [Comment("Foreign key")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Navigation property for category")]
        public virtual Category Category { get; set; } = null!;

        [Comment("Discounts for vehicle")]
        public virtual ICollection<VehicleDiscount> VehicleDiscounts { get; set; } = new HashSet<VehicleDiscount>();

    }
}
