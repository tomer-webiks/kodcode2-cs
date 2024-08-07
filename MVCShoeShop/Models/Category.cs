using System.ComponentModel.DataAnnotations;

namespace MVCShoeShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name {  get; set; }

        public List<Shoe> Shoes { get; set; }
    }
}
