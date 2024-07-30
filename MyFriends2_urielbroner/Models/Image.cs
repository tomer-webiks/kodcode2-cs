using System.ComponentModel.DataAnnotations;

namespace MyFriends2.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public Friend Friend { get; set; }
        
        [Display (Name ="תמונה")]
        public byte[] MyImage { get; set; }


    }
}