using ASP.NET_EducationPlatform.Data;
using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPlatfotm.Domain.Users
{
    public class Student : FIO, IEntity
    {        

        [Display(Name = "Класс")]
        public int YearStudy { get; set; }

        [Display(Name = "Изучаемые предметы")]
        public List<Subject> Subjects { get; set; } = new()
        {
            new Subject{Name = "Физика", IsInvolved = true},
            new Subject{Name = "Математика", IsInvolved = false},
            new Subject { Name = "Обществознание", IsInvolved = false },
            new Subject { Name = "Русский язык", IsInvolved = false },
            new Subject { Name = "География", IsInvolved = false },
        };


        public bool IsInvolved { get; set; }
    }
}
