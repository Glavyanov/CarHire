namespace CarHire.Core.Models.Discount
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    using static CarHire.Infrastructure.Data.ValidationConstants.DiscountConstants;

    public class DiscountAddModel
    {
        [HiddenInput(DisplayValue = false)]
        public string? Id { get; set; }

        [Required]
        [Display(Name = "Discount size")]
        [Range(DiscountSizeMinRange, DiscountSizeMaxRange,
            ErrorMessage = "The {0} must be at least {1} and at max {2} percentages.")]
        public int DiscountSize { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Expire on")]
        public DateTime ExpireOn { get; set; }
    }
}
