namespace CarHire.Infrastructure.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ValidationConstants.ApplicationUserConstants;

    [Comment("Application user: extended AspNetCore IdentityUser")]
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(FirstNameMaxLength)]
        [Comment("Application user first name")]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("Application user last name")]
        public string? LastName { get; set; }
    }
}
