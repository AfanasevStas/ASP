using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        //[StringLength(50,MinimumLength=2)]
        [MinLength(2, ErrorMessage="Слишком малый текст"), MaxLength(50, ErrorMessage = "Слишком малый текст")]
        public string Title { get; set; }
        [RangeAttribute(typeof(DateOnly), "1888-10-14", "2128-12-31", ErrorMessage = "Либо не снимали, либо ещё не успели снять")]
        [Display(Name ="Дата выхода")]
        public DateOnly ReleaseDate { get; set; }
        [DisplayName("Жанр")]
        public string? Genre { get; set; }
        public string? URL { get; set; }
        public string Poster { get; set; }
    }
}
