namespace LibraryClassExercise.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<Book>? Books { get; set; }
        public Library Library { get; set; }
    }
}
