using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebHike.Data;
using WebHike.Data.Entities;
using WebHike.Models.Category;

namespace WebHike.Controllers;

public class MainController(HikeDbContext hikeDbContext) 
    : Controller
{
    //private readonly HikeDbContext _hikeDbContext;
    //public MainController(HikeDbContext hikeDbContext)
    //{
    //    _hikeDbContext = hikeDbContext;
    //}
    //Методи у ASP.NET - звуться Action - дія
    public IActionResult Index()
    {
        //Контролер дані передає на певну View
        //View - це звичайна html сторінка із
        //кодом C# - Razor View
        //return "Привіт козаки :)";
        //так краще не робити :(
        var list = hikeDbContext.Categories.ToList();
        return View(list); //Передаю дані на View - список категорій
    }
    //Метод для створення категорії нової
    [HttpGet] //Для відображення фоми
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost] //Цей метод спрацьовує коли кидає Post Request
    public IActionResult Create(CategoryCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.Name = model.Name;
            categoryEntity.Slug = model.Slug;
            categoryEntity.Image = "default.jpg";
            if (model.Image != null)
            {
                var dirName = "images";
                var dirCurrent = Directory.GetCurrentDirectory();
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string fileSave = Path.Combine(dirCurrent, "wwwroot", dirName, fileName);

                using var stream = new FileStream(fileSave, FileMode.Create);
                model.Image.CopyTo(stream); // Зберігаю передані байти у вказаний файл

                categoryEntity.Image = fileName; //в БД зберігаю назву файла
            }

            hikeDbContext.Categories.Add(categoryEntity);
            hikeDbContext.SaveChanges();

            return Redirect(nameof(Index)); //Повертаюся на список категорій
        }
        
        return View(model); // Що прийшло те іде назад
    }
}
