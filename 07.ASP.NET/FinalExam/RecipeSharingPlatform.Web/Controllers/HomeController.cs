using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RecipeSharingPlatform.ViewModels;
using RecipeSharingPlatform.Web.Controllers;

public class HomeController : BaseController
{

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Index()
    {
        try
        {
            if(IsUserAuthenticated())
            {
                return this.RedirectToAction(nameof(Index), "Recipe");
            }

            return this.View();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        } 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}