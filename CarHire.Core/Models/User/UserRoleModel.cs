using CarHire.Core.Models.Role;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarHire.Core.Models.User
{
    public class UserRoleModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        [Display(Name = "Role")]
        public string RoleId { get; set; } = null!;

        public List<RoleModel> Roles { get; set; } = new List<RoleModel>();
    }
}
