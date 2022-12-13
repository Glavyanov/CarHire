namespace CarHire.Areas.Administration.Controllers
{
    using CarHire.Core.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using static CarHire.Infrastructure.Data.ValidationConstants;

    public class RoleController : BaseController
    {
        private readonly IUserService userService;

        public RoleController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsersAsync();

            return View(users);
        }

        [HttpPost]
        public async  Task<IActionResult> Index(
            [FromForm(Name ="item.Id")]string userId, 
            [FromForm(Name ="item.RoleId")]string roleId)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(roleId) )
            {
                try
                {
                    await userService.AddUserToRoleAsync(userId, roleId);

                    TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageAddUserToRole;
                }
                catch (ArgumentException)
                {
                    TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageAddUserExistToRole;
                }
                
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageAddUserToRole;

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Remove()
        {
            var users = await userService.GetAllUsersAsync();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(
            [FromForm(Name = "item.Id")] string userId,
            [FromForm(Name = "item.RoleId")] string roleId)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(roleId))
            {
                try
                {
                    await userService.RemoveUserFromRoleAsync(userId, roleId);
                    TempData[MessageConstant.WarningMessage] = MessageConstant.WarningMessageRemoveUserFromRole;
                }
                catch (ArgumentException)
                {
                    TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageRemoveUserFromRoleNotExists;
                }

            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.ErrorMessageRemoveUserFromRole;

            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
