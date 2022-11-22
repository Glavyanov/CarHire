namespace CarHire.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using static CarHire.Infrastructure.Data.ValidationConstants.RolesConstants;


    [Authorize(Roles = Admin)]
    [Area("Administration")]
    public class BaseController : Controller
    {
    }
}
