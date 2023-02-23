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
            new Subject{Name = "Физика", IsInvolved = true},
            new Subject{Name = "Математика", IsInvolved = false},
            new Subject{Name = "Обществознание", IsInvolved = false},
            new Subject{Name = "Русский язык", IsInvolved = false},
            new Subject{Name = "География", IsInvolved = false},
        };

        

    }
}
