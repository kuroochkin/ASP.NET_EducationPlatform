using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public Subject Subject { get; set; } = null!;

        [Required]
        [Display(Name = "Направление")]
        public string Direction { get; set; } = null!;

        [Required]
        [Display(Name = "Преподаватель")]
        public Teacher Teacher { get; set; } = null!;

        [Required]
        [Display(Name = "Ученики")]
        public ICollection<Student> Students { get; set; }
    }
}
