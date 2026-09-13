using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Classes
{
    public class Students
    {
        [Key]
        public int stud_id { get; set; }
        public string? last_name { get; set; }
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public DateOnly birth_date { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public byte[]? Photo { get; set; }
        public int group { get; set; }
    }
}
