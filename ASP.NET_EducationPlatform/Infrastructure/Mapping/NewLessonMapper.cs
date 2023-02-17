using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using ASP.NET_EducationPlatform.ViewModels;
using EducationPlatfotm.Domain.Users;
using EducationPlatfotm.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_EducationPlatform.Infrastructure.Mapping
{
    public static class NewLessonMapper
    {
        public static EditLessonViewModel ToView()
        {
            var model = new EditLessonViewModel()
            {
                
            };

            var teachers = TestData.teachers;
            var students = TestData.students;
            var subjects = TestData.subjects;

            foreach (var teacher in teachers)
            {
                model.TeacherSelectList.Add(new SelectListItem
                {
                    Text = teacher.fio,
                    Value = Convert.ToString(teacher.Id),
                });
            }

            foreach (var subject in subjects)
            {
                model.SubjectSelectList.Add(new SelectListItem
                {
                    Text = subject.Name,
                    Value = Convert.ToString(subject.Id),
                });
            }

            foreach (var student in students)
            {
                var sub = student.Subjects.Where(s => s.IsInvolved == true);
                
                {
                    
                    
                        model.StudentSelectList.Add(new SelectListItem
                        {
                            Text = student.fio,
                            Value = Convert.ToString(student.Id),
                        });
                    
                }
            }

            return model;
        }

        
    }
}
