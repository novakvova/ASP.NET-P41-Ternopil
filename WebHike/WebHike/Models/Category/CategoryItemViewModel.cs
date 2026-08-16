namespace WebHike.Models.Category;

//Для відображення категорій на сайті
public class CategoryItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
}
