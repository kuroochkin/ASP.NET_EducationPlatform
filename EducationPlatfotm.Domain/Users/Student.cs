using EducationPlatfotm.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Users
{
    public class Student : FIO
    {
        public int YearStudy { get; set; }
    }
}
