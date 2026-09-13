using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Classes
{
    public class Groups
    {
        [Key]
        public int group_id { get; set; }
        public string? group_name { get; set; }
        public int direction { get; set; }
        public DateOnly start_date { get; set; }
        public TimeOnly start_time { get; set; }
        public int learning_days { get; set; }
    }
}
