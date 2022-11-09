namespace CarHire.Core.Models.User
{
    using System.ComponentModel.DataAnnotations;
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
