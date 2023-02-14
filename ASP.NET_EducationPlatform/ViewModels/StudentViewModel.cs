using EducationPlatfotm.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class StudentViewModel
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

        public int YearStudy { get; set; }

        [Display(Name = "Изучаемые предметы")]
        public List<Subject> Speciality { get; set; }
    }
}
