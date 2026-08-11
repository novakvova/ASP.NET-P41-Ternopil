using Microsoft.AspNetCore.Mvc;

namespace WebHike.Areas.Admin.Controllers;

[Area("Admin")]
public class IconsController : Controller
{
  public IActionResult RiIcons() => View();
}
