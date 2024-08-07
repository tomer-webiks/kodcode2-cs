using MVCShoeShop.Models;

namespace MVCShoeShop.ViewModels;

public class ShoeWithCategories
{
    public Shoe? Shoe { get; set; }
    public List<Category>? Categories;
    public int SelectedCategoryId;
}
