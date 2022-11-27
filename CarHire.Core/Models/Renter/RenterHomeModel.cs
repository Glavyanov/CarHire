namespace CarHire.Core.Models.Renter
{
    public class RenterHomeModel
    {
        public string Id { get; set; } = null!;

        public DateTime RegisteredOn { get; set; }

        public string DrivingLicenseNumber { get; set; } = null!;

        public decimal TotalValue { get; set; }

        public int RenterDiscount { get; set; }

        public string ApplicationUserId { get; set; } = null!;

        public string VehicleId { get; set; } = null!;

        public decimal HiredCarPricePerDay { get; set; }

    }
}
