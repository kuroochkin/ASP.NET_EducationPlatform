using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Data
{
    public static class TestData
    {
        
        public static List<Teacher> teachers { get; set; } = new()
        {
            new Teacher {LastName = "Келин", FirstName = "Кирилл", Patronymic = "Вячеславович"},
            new Teacher {LastName = "Курочкин", FirstName = "Владислав", Patronymic = "Романович"},
        };


        public static List<Student> students { get; set; } = new()
        {
            new Student {LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", YearStudy = 9},
            new Student {LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", YearStudy = 11},
        };

        public static List<Subject> subjects { get; set; } = new()
        {
            new Subject{Name = "Физика", IsInvolved = true},
            new Subject{Name = "Математика", IsInvolved = false},
            new Subject{Name = "Обществознание", IsInvolved = false},
            new Subject{Name = "Русский язык", IsInvolved = false},
            new Subject{Name = "География", IsInvolved = false},
        };

        public static List<Lesson> lessons { get; set; } = new()
        {
            new Lesson
            { 
                DateTime = new DateTime(2023,6,6),
                Subject = new Subject {Name = "Физика", IsInvolved = false },
                Direction = "ОГЭ",
                Teacher = new Teacher {LastName = "Келин", FirstName = "Кирилл", Patronymic = "Вячеславович"},
                Student = new Student {LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", YearStudy = 9},
            },
        };

        
    }
}
    

        
 

