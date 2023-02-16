using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class EditLessonViewModel
    {
        public int LessonId { get; set; }

        public List<SelectListItem> SubjectSelectList { get; set; } = new List<SelectListItem>();

        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }

        public string SelectedSubject { get; set; }

        [Display(Name = "Дата занятия")]
        public DateTime Date { get; set; }

        [Display(Name = "Направление")]
        public string Direction { get; set; }

        public List<SelectListItem> TeacherSelectList { get; set; } = new List<SelectListItem>();

        [Display(Name = "Преподаватель")]
        public string TeacherFullName { get; set; }

        public string SelectedTeacher { get; set; }

        public List<SelectListItem> StudentSelectList { get; set; } = new List<SelectListItem>();

        [Display(Name = "Ученик")]
        public string StudentFullName { get; set; }

        public string SelectedStudent { get; set; }
    }
}
