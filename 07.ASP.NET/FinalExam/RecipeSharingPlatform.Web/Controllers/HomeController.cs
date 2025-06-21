using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.ViewModels;
using RecipeSharingPlatform.Web.Controllers;

public class HomeController : BaseController
{

    [HttpGet]
    public IActionResult Index()
    {
        try
        {
            if(IsUserAuthenticated())
            {
                return RedirectToAction(nameof(Index), "Recipe");
            }
            return View();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction(nameof(Index));
        } 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}