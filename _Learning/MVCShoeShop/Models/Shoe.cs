using System.ComponentModel.DataAnnotations;

namespace MVCShoeShop.Models
{
    public class Shoe
    {
        [Key]
        public int Id { get; set; }

        public string Color {  get; set; }

        public int Size { get; set; }

        public List<Image> Images { get; set; }

        public Category? Category { get; set; }
    }
}
