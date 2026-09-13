using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Classes
{
    public class Disciplines
    {
        [Key]
        public int discipline_id { get; set; }
        public string? discipline_name { get; set; }
        public int number_of_lessons { get; set; }
    }
}
