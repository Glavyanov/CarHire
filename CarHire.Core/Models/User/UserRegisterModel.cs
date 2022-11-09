namespace CarHire.Core.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static CarHire.Infrastructure.Data.ValidationConstants.ApplicationUserConstants;

    public class UserRegisterModel
    {
        [EmailAddress]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmedPassword { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string FirstName { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string LastName { get; set; } = null!;
    }
}
