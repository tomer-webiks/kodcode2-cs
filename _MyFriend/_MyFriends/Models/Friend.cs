

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Friends_Img.Models
{
    public class Friend
    {
        [Key]
        public int ID {  get; set; }

        [Display(Name = "first name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "last name")]

        public string LastName { get; set; } = string.Empty;

        [Display(Name = "phone number"),Phone(ErrorMessage = "Phone isn't valid")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "email address"), EmailAddress(ErrorMessage = "Email isn't valid")]
        public string EmailAddress { get; set; } = string.Empty;
        public List<Image> Images { get; set; }


        [Display(Name = "add image"), NotMapped]
        public IFormFile setImage
        {
            get { return null; }
            set
            {
                if (value == null) return;
                AddImage(value);
            }
        }
        public Friend()
        {
            Images = new List<Image>();
        }

        public void AddImage(byte[] img)
        {
            Images.Add(new Image { MyImage = img, Friend = this });
        }
        public void AddImage(IFormFile img)
        {
            MemoryStream stream = new MemoryStream();
            img.CopyTo(stream);
            AddImage(stream.ToArray());
        }

    }
}
