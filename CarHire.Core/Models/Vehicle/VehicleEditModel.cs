namespace CarHire.Core.Models.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using CarHire.Core.Models.Enum;
    using Microsoft.AspNetCore.Mvc;
    using static CarHire.Infrastructure.Data.ValidationConstants.VehicleConstants;
    public class VehicleEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(MakeMaxLength, MinimumLength = MakeMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Make { get; set; } = null!;

        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Model { get; set; } = null!;

        public int Kilometers { get; set; }

        public bool AirCondition { get; set; }

        public bool NavigationSystem { get; set; }

        [Range(SeatsMinRange, SeatsMaxRange,
            ErrorMessage = "The {0} must be at least {1} and at max {2}")]
        public int Seats { get; set; }

        [Range(DoorsMinRange, DoorsMaxRange,
            ErrorMessage = "The {0} must be at least {1} and at max {2}")]
        public int Doors { get; set; }

        [Display(Name = "Suspension")]
        public int SuspensionId { get; set; }

        public IEnumerable<SuspensionModel> Suspensions { get; set; } = new List<SuspensionModel>();

        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        public IEnumerable<FuelModel> Fuels { get; set; } = new List<FuelModel>();

        [Display(Name = "Transimission")]

        public int TransmissionId { get; set; }

        public IEnumerable<TransmissionModel> Transmissions { get; set; } = new List<TransmissionModel>();

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<VehicleCategoryModel> VehicleCategories { get; set; } = new List<VehicleCategoryModel>();

        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string ImageUrl { get; set; } = null!;

        public int? TankCapacity { get; set; }

        public double? Consumption { get; set; }

        [Range(typeof(decimal), PriceMinRange, PriceMaxRange, ConvertValueInInvariantCulture = true)]
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsRented { get; set; }

    }
}
