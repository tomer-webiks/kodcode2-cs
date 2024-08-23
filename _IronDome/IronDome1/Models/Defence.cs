using System.ComponentModel.DataAnnotations;

namespace IronDome.Models
{
    public enum DEFENCE_TYPE
    {
        IRON_DOME
    }

    public class Defence
    {
        [Key]
        public int ID { get; set; }
        public int Ammunition { get; set; }
    }
}
