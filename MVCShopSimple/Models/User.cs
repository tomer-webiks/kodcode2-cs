using System.ComponentModel.DataAnnotations;

namespace MVCShopSimple.Models
{
    public class User
    {
        [Key] // Denotes the primary key
        public int UserId { get; set; }

        [Required] // Marks the field as required
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
