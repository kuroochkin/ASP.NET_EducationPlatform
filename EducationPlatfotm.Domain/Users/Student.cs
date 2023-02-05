using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Users
{
    public class Student : FIO, IEntity
    {
        public int Id { get; set; }
        public int YearStudy { get; set; }
    }
}
