using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebHike.Data;
using WebHike.Data.Entities;
using WebHike.Interfaces;
using WebHike.Models.Category;

namespace WebHike.Controllers;

public class MainController(HikeDbContext hikeDbContext,
    IImageService imageService) 
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
    public async Task<IActionResult> Create(CategoryCreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.Name = model.Name;
            categoryEntity.Slug = model.Slug;
            categoryEntity.Image = "default.jpg";
            if (model.Image != null)
            {
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                // Фото стискається на сервері (ImageSharp): зменшується до
                // розумного розміру та перекодовується у JPEG з компресією,
                // тож 2 Мб з телефону не стають 2 Мб на сайті.
                var fileName = await imageService.SaveOptimizedImageAsync(model.Image, folderPath);

                categoryEntity.Image = fileName; //в БД зберігаю назву файла
            }

            hikeDbContext.Categories.Add(categoryEntity);
            hikeDbContext.SaveChanges();

            return Redirect(nameof(Index)); //Повертаюся на список категорій
        }
        
        return View(model); // Що прийшло те іде назад
    }
}
