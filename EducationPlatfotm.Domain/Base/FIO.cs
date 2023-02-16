using EducationPlatfotm.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Base
{
    public class FIO : IFIO
    {
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        public string fio
        {
            get => LastName + " " + FirstName + " " + Patronymic;
            set { value = LastName + " " + FirstName + " " + Patronymic; }
        }
    }
}
