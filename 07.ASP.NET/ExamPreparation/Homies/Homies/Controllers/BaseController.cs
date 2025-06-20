namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            string? userId = null;

            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}