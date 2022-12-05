namespace CarHire.Core.Models.Role
{
    using Microsoft.AspNetCore.Mvc;
    public class RoleModel
    {
        public string Id { get; set; } = null!;

        [HiddenInput(DisplayValue = false)]
        public string RoleName { get; set; } = null!;
    }
}
