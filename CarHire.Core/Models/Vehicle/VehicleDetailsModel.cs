namespace CarHire.Core.Models.Vehicle
{
    using System.ComponentModel.DataAnnotations;

    using CarHire.Core.Models.Discount;

    public class VehicleDetailsModel
    {
        public string Id { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public bool AirCondition { get; set; }

        public bool NavigationSystem { get; set; }

        public bool IsRented { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public string Suspension { get; set; } = null!;

        public string Transmission { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int? TankCapacity { get; set; }

        public double? Consumption { get; set; }

        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; set; }

        public string FuelType { get; set; } = null!;

        public List<DiscountHomeModel> Discounts { get; set; } = new List<DiscountHomeModel>();

    }
}
