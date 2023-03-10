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

        
        [Display(Name = "Дата")]
        public DateTime DateTime { get; set; }

       
        [Display(Name = "Предмет")]
        public string Subject { get; set; } = null!;

        
        [Display(Name = "Направление")]
        public string Direction { get; set; } = null!;

        
        [Display(Name = "Преподаватель")]
        public string TeacherFIO { get; set; } = null!;

        
        [Display(Name = "Ученики")]
        public ICollection<Student> Students { get; set; }

        public List<SelectListItem> TeacherSelectList { get; set; } = new List<SelectListItem>();

        public string FIO { get;set; }
        

    }
}
