using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class EditLessonViewModel
    {
        public int LessonId { get; set; }
        public DateTime Date { get; set; }

        public string Direction { get; set; }

        public string TeacherFullName { get; set; }


        public List<SelectListItem> TeacherSelectList { get; set; } = new List<SelectListItem>();
        public string Selected { get; set; }
    }
}
