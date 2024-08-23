using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace My_Friends_Img.Models
{
    public class Image
    {
        [Key]
        public int ID {  get; set; }
        public Friend Friend { get; set; }

        [Display(Name ="img")]
        public byte[] MyImage { get; set; }

    }
}