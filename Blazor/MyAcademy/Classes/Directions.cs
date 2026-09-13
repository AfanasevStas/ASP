using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Classes
{
    public class Directions
    {
        [Key]
        public int direction_id { get; set; }
        public string? direction_name { get; set; }
    }
}
