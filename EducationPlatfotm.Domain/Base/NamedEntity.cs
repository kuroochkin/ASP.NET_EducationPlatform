using EducationPlatfotm.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Base
{
    public class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
