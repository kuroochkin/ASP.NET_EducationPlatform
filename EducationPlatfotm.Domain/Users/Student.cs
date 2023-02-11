using EducationPlatfotm.Domain.Base;
using EducationPlatfotm.Domain.Base.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace EducationPlatfotm.Domain.Users
{
    public class Student : FIO, IEntity
    {
        public int Id { get; set; }
        
        [Display(Name = "Класс")]
        public int YearStudy { get; set; }

        [Display(Name = "Изучаемые предметы")]
        public ICollection<Subject> Subjects { get; set; } = null!;
    }
}
