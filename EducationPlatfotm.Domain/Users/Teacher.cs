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
        public List<Subject> Subjects { get; set; } = new()
        {
            new Subject{Id = 1, Name = "Физика", IsInvolved = true},
            new Subject{Id = 2, Name = "Математика", IsInvolved = false},

        };
    }
}
