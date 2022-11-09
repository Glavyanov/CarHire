namespace CarHire.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using static CarHire.Infrastructure.Data.ValidationConstants.ClaimsConstants;


    [Authorize]
    public class BaseController : Controller
    {
        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;

                if (User != null && User.HasClaim(c => c.Type == FirstName))
                {
                    firstName = User.Claims.FirstOrDefault(c => c.Type == FirstName)?.Value ?? firstName;
                }

                return firstName;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewBag.UserFirstName = UserFirstName;
            base.OnActionExecuted(context);
        }
    }
}
