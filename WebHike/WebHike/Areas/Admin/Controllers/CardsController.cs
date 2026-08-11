using Microsoft.AspNetCore.Mvc;

namespace WebHike.Areas.Admin.Controllers;

[Area("Admin")]
public class CardsController : Controller
{
  public IActionResult Basic() => View();
}
