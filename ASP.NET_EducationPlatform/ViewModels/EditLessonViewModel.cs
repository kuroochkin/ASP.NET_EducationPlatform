﻿using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.NET_EducationPlatform.ViewModels
{
    public class EditLessonViewModel
    {
        
        public int LessonId { get; set; }

        [Display(Name = "Дата занятия")]
        public DateTime Date { get; set; }

        [Display(Name = "Направление")]
        public string Direction { get; set; }

        [Display(Name = "Преподаватель")]
        public string TeacherFullName { get; set; }


        public List<SelectListItem> TeacherSelectList { get; set; } = new List<SelectListItem>();

        public List<Student> StudentsSubj { get; set; } = new List<Student>();// список студентов у которых есть предмет lesson.Subject

        public string Selected { get; set; }
    }
}
