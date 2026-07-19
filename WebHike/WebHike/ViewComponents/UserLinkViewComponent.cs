using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebHike.Data.Entities.Identity;
using WebHike.Models.Account;

namespace WebHike.ViewComponents;

public class UserLinkViewComponent(UserManager<UserEntity> userManager) 
    : ViewComponent
{
    //Він не може бути асихроний
    public IViewComponentResult Invoke()
    {
        var userName = User.Identity?.Name;
        var model = new UserLinkViewModel();
        if(userName != null)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            model.Name = $"{user.LastName} {user.FirstName}";
            model.Image = $"/images/{user.Image}_64.webp";
        }

        return View(model);
    }
}
