namespace CarHire.Core.Models.Discount
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    public class DiscountsVehicleModel
    {
        [HiddenInput(DisplayValue = false)]
        public string VehicleId { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Discounts:")]
        public string DiscountId { get; set; } = null!;

        public List<DiscountHomeModel> Discounts { get; set; } = new List<DiscountHomeModel>();
    }
}
