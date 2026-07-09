using Microsoft.AspNetCore.Mvc;
using WebHike.Data;

namespace WebHike.Controllers;

public class ProductsController(HikeDbContext hikeDbContext) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult ProdCreate()
    {
        //отримую із БД назва категорій
        //Кладу у спеціальну динамічну колекцію, яка буде доступна на View
        ViewBag.Categories = hikeDbContext
            .Categories.Select(x => x.Name).ToList();
        return View();
    }
}
