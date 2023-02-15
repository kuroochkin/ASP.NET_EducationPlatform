using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace EducationPlatfotm.Domain.Users
{
    public class Student : FIO, IEntity
    {
        public int Id { get; set; }
        
        [Display(Name = "Класс")]
        public int YearStudy { get; set; }

        [Display(Name = "Изучаемые предметы")]
        public List<Subject> Subjects { get; set; } = new()
        {
            new Subject{Id = 1, Name = "Физика", IsInvolved = true },
            new Subject{Id = 2, Name = "Математика", IsInvolved = false},
            new Subject{Id = 3, Name = "Обществознание", IsInvolved = false},
            new Subject{Id = 4, Name = "Русский язык", IsInvolved = false},
            new Subject{Id = 5, Name = "География", IsInvolved = false},
        };

        public bool IsInvolved { get; set; }
    }
}
