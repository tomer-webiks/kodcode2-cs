using System.ComponentModel.DataAnnotations;

namespace LibraryClassExercise.Models
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set;  }
        public Shelf Shelf { get; set; }

        public int Dimensions
        {
            get
            {
                return Height * Width;
            }
        }
    }
}
