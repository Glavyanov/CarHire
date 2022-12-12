namespace CarHire.Core.Models.Category
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using static CarHire.Infrastructure.Data.ValidationConstants.CategoryConstants;

    public class CategoryHomeModel
    {
        [HiddenInput(DisplayValue = false)]
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,
           ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Name { get; set; } = null!;
    }
}
