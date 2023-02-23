using EducationPlatfotm.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EducationPlatfotm.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        [Display(Name = "Преподаваемый премет")]
        public string Name { get; set; }

        public bool IsInvolved { get; set; }
    }
}
