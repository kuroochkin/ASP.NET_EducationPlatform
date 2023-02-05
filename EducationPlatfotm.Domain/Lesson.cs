using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain
{
    public class Lesson : Entity
    {
        public string Subject { get; set; } = null!;

        public string Direction { get; set; } = null!;

        public Teacher Teacher { get; set; } = null!;

        public ICollection<Student> Students { get; set; }
    }
}
