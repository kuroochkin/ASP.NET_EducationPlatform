using ASP.NET_EducationPlatform.Components.Teachers;
using ASP.NET_EducationPlatform.Data;
using EducationPlatfotm.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательна!")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Некорректный ввод")]
        public string LastName { get; set; }
        
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя обязательно!")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Некорректный ввод")]
        public string FirstName { get; set; }
        
        [Display(Name = "Отчество")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Некорректный ввод")]
        public string Patronymic { get; set; }

        [Display(Name = "Преподаваемые предметы")]
        public List<Subject> Speciality { get; set; } = TestData.subjects;

        public string FIO => LastName + FirstName + Patronymic;

        
    }
}
