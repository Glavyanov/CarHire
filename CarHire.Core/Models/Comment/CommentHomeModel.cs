namespace CarHire.Core.Models.Comment
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using static CarHire.Infrastructure.Data.ValidationConstants.CommentConstants;


    public class CommentHomeModel
    {
        [HiddenInput(DisplayValue = false)]
        public string VehicleId { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Description { get; set; } = null!;
    }
}
