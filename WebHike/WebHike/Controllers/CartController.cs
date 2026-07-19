using Microsoft.AspNetCore.Mvc;

namespace WebHike.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
