using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class LessonViewModel
    {   
        public int Id { get; set; }

        public string Selected { get; set; }

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

        public int TeacherId { get; set; }

        public string TeacherName { get; set; } 

        [Required]
        [Display(Name = "Ученики")]
        public ICollection<Student> Students { get; set; }

        public List<Teacher> TeacherSelectList { get; set; } = new List<Teacher>();

        public string ByFIO()
        {
            return Teacher.LastName + " " + Teacher.FirstName + " " + Teacher.Patronymic;
        }
        
    }
}
