using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCShoeShop.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [Required]
        public string ContentType { get; set; }

        //[ForeignKey("ShoeId")]
        //public int ShoeId { get; set; }
        public Shoe Shoe { get; set; }
    }
}
