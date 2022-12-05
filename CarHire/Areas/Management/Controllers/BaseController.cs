namespace CarHire.Areas.Management.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static CarHire.Infrastructure.Data.ValidationConstants.RolesConstants;

    [Authorize(Roles = Manager)]
    [Area("Management")]
    public class BaseController : Controller
    {
        
    }
}
