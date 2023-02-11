﻿using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Data
{
    public static class TestData
    {
        public static List<Teacher> teachers { get; } = new()
        {
            new Teacher {Id = 1, LastName = "Келин", FirstName = "Кирилл", Patronymic = "Вячеславович"},
            new Teacher {Id = 2, LastName = "Курочкин", FirstName = "Владислав", Patronymic = "Романович"},
        };


        public static List<Student> students { get; } = new()
        {
            new Student {Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", YearStudy = 9},
            new Student {Id = 1, LastName = "Петров", FirstName = "Петр", Patronymic = "Петрович", YearStudy = 11},
        };

        public static List<Subject> subjects { get; } = new()
        {
            new Subject{Name = "Инглиш"},
            new Subject{Name = "Русский"}

        };
    }
}
    

        
 

