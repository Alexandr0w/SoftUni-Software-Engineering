using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace RecipeSharingPlatform.Web.Controllers
{
    public abstract class BaseController : Controller
    {
       protected bool IsUserAuthenticated()
        {
            return this.User.Identity?.IsAuthenticated ?? false;
        }
        protected string GetUserId()
        {
            string? userId = null;

            bool IsAuthenticated = this.IsUserAuthenticated();
            if(IsAuthenticated)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId!;
        }
     
    }
}
