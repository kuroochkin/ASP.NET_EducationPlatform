using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EducationPlatfotm.Domain
{
    public class Lesson : Entity
    {
        [Required]
        [Display(Name = "Дата")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public Subject Subject { get; set; } = null!;

        [Required]
        [Display(Name = "Направление")]
        public string Direction { get; set; } = null!;

        [Required]
        [Display(Name = "Преподаватель")]
        public Teacher Teacher { get; set; } = null!;

        public string FIOTeacher { get; set; }


        [Required]
        [Display(Name = "Ученики")]
        public ICollection<Student> Students { get; set; }
    }
}
