using Microsoft.AspNetCore.Mvc;

namespace WebHike.Controllers;

public class MainController : Controller
{
    //Методи у ASP.NET - звуться Action - дія
    public IActionResult Index()
    {
        //Контролер дані передає на певну View
        //View - це звичайна html сторінка із
        //кодом C# - Razor View
        //return "Привіт козаки :)";
        return View();
    }
}
