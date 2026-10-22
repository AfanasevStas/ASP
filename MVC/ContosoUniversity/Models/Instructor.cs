using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата трудоустройства")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Преподаватель")]
        public string FullName
        {
            get => $"{LastName} {FirstName}";
        }

        public OfficeAssignment OfficeAssignment { get; set; }
        public ICollection<CourseAssignment> CourseAssignment { get; set; }
    }
}
