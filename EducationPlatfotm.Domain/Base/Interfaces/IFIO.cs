﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Base.Interfaces
{
    public interface IFIO
    {
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        
        public string Patronymic { get; set; }

        public string fio { get; set; }
    }
}
