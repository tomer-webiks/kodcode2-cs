using System.ComponentModel.DataAnnotations;

namespace LibraryClassExercise.Models
{
    public class Library
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Shelf>? Shelves { get; set; }
    }
}
