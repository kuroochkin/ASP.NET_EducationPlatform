using EducationPlatfotm.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatfotm.Domain.Base
{
    public class FIO : IFIO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [NotMapped]
        public string fio
        {
            get => LastName + " " + FirstName + " " + Patronymic;
            set { value = LastName + " " + FirstName + " " + Patronymic; }
        }
    }
}
