namespace Horizons.Web.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated()
        {
            return this.User.Identity?.IsAuthenticated ?? false;
        }

        protected string? GetUserId()
        {
            string? userId = null;

            bool isAuthenticated = this.IsUserAuthenticated();

            if (isAuthenticated)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
