using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Users
{
    public class Teacher : FIO, IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Преподаваемые предметы")]
        public List<Subject> Subjects { get; set; } = new()
        {
            new Subject{Id = 1, Name = "Физика", IsInvolved = false},
            new Subject{Id = 2, Name = "Математика", IsInvolved = false},
            new Subject{Id = 3, Name = "Обществознание", IsInvolved = false},
            new Subject{Id = 4, Name = "Русский язык", IsInvolved = false},
            new Subject{Id = 5, Name = "География", IsInvolved = false},
        };

        public string FIO
        {
            get => LastName + " " + FirstName + " " + Patronymic;
            set { value = LastName + " " + FirstName + " " + Patronymic; }
        }

    }
}
