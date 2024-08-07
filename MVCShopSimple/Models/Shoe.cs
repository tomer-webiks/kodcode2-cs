using System.ComponentModel.DataAnnotations;

namespace MVCShopSimple.Models
{
    public class Shoe
    {
        [Key] // Denotes the primary key
        public int Id { get; set; }

        [Required] // Marks the field as required
        [StringLength(100, MinimumLength = 3)]
        public string Color { get; set; }


        [Required] // Marks the field as required
        [StringLength(100, MinimumLength = 3)]
        public string Size { get; set; }
    }
}
