using ASP.NET_EducationPlatform.Data;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;

using System.ComponentModel.DataAnnotations;


namespace EducationPlatfotm.Domain.Users
{
    public class Teacher : FIO, IEntity
    {
        [Display(Name = "Преподаваемые предметы")]
        public List<Subject> Subjects { get; set; } = new()
        {
            new Subject{Name = "Физика", IsInvolved = true},
            new Subject{Name = "Математика", IsInvolved = false},
            new Subject { Name = "Обществознание", IsInvolved = false },
            new Subject { Name = "Русский язык", IsInvolved = false },
            new Subject { Name = "География", IsInvolved = false },
        };
    }
}
