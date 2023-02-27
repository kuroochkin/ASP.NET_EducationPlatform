using EducationPlatfotm.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace EducationPlatfotm.Domain
{
    [Index(nameof(Name), IsUnique = true)]
    public class Subject : NamedEntity
    {
        
        public bool IsInvolved { get; set; }
    }
}
