using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Classes
{
    public class Teachers
    {
        [Key]
        public int teacher_id { get; set; }
        public string? last_name { get; set; }
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public DateOnly birth_date { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public byte[]? Photo { get; set; }
        public DateOnly work_since { get; set; }
        public decimal? rate { get; set; }

    }
}

