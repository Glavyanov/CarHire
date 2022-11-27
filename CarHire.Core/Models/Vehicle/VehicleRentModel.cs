namespace CarHire.Core.Models.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    using static CarHire.Infrastructure.Data.ValidationConstants.RenterConstants;

    public class VehicleRentModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string ImageUrl { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public bool IsRented { get; set; }

        [Required]
        [StringLength(DrivingLicenseNumberMaxLength, MinimumLength = DrivingLicenseNumberMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string DrivingLicense { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string RenterId { get; set; } = null!;

        [Range(MinRentDays, MaxRentDays,
            ErrorMessage = "The {0} must be at least {1} and at max {2} days.")]
        public int RentDays { get; set; }

        [HiddenInput(DisplayValue = false)]
        public decimal PricePerDay { get; set; }
    }
}
