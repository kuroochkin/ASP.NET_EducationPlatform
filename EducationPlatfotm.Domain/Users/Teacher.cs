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
        public string Speciality { get; set; } = null!;
    }
}
