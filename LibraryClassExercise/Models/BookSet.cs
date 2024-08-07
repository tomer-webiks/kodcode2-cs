namespace LibraryClassExercise.Models
{
    public class BookSet : IBook
    {
        public int Id { get; set; }
        public int Width {  get; set; }
        public int Height { get; set; } 
        public List<Book> books {  get; set; }

        public int Dimensions
        {
            get
            {
                int totalWidth = 0;
                if (books != null)
                {
                    foreach (var item in books)
                    {
                        totalWidth += item.Width;
                    }

                    return totalWidth * Height;
                }

                return 0;
                
            }
        }
    }
}
