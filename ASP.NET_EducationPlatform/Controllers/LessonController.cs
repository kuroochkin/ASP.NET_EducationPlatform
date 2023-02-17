using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using ASP.NET_EducationPlatform.ViewModels;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_EducationPlatform.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonData _lessonsData;
        private readonly ITeacherData _teacherData;
        private readonly IStudentData _studentData;
        private readonly ISubjectData _subjectData;

        public LessonController(
            ILessonData lessonData, 
            ITeacherData teacherData, 
            IStudentData studentData, 
            ISubjectData subjectData)
        {
            _lessonsData = lessonData;
            _teacherData = teacherData;
            _studentData = studentData;
            _subjectData = subjectData;
        }

        public IActionResult Index()
        {
            var lessons = _lessonsData.GetAllLessons();

            return View(lessons);
        }

        public IActionResult Details(int id)
        {
            var lesson = _lessonsData.GetById(id);

            if (lesson is null)
                return NotFound();

            return View(lesson);
        }

        public IActionResult NullStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EditLessonViewModel()); 

            var lesson = _lessonsData.GetById((int)id);
            if (lesson is null)
                return NotFound();

            var teachers = _teacherData.GetAllTeachers();
            var students = _studentData.GetAllStudents();
            var subjects = TestData.subjects;

            var model = new EditLessonViewModel()
            {
                LessonId = lesson.Id,
                Date = lesson.DateTime,
                Direction = lesson.Direction,
                TeacherFullName = lesson.Teacher.fio,
                SubjectName = lesson.Subject.Name,
                StudentFullName = lesson.Student.fio,
                SelectedTeacher = lesson.Teacher.Id.ToString(),
                SelectedSubject = lesson.Subject.Id.ToString(),
                SelectedStudent = lesson.Student.Id.ToString(),
            };

            foreach (var teacher in teachers)
            {
                model.TeacherSelectList.Add(new SelectListItem
                {
                    Text = teacher.fio,
                    Value = Convert.ToString(teacher.Id),
                });
            }

            foreach(var subject in subjects)
            {
                model.SubjectSelectList.Add(new SelectListItem
                {
                    Text = subject.Name,
                    Value = Convert.ToString(subject.Id),
                });
            }

            //foreach(var student in students)
            //{
            //    model.StudentSelectList.Add(new SelectListItem
            //    {
            //        Text = student.fio,
            //        Value = Convert.ToString(student.Id),
            //    });
            //}

            foreach (var student in students)
            {
                var sub = student.Subjects.Where(s => s.IsInvolved == true);
                foreach (var item in sub)
                {
                    if (item.Name == model.SubjectName)
                    {
                        model.StudentSelectList.Add(new SelectListItem
                        {
                            Text = student.fio,
                            Value = Convert.ToString(student.Id),
                        });
                    }    
                }
            }

            if (model.StudentSelectList.Count == 0)
                return View("NullStudent");

            //var les = lesson.Student.Subjects.FirstOrDefault(s => s.Id == lesson.Subject.Id);

            //if (lesson.Subject.Id != les.Id)
            //    return View("NullStudent");

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditLessonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var lesson = _lessonsData.GetById(model.LessonId);

            if (lesson is null)
                return BadRequest();

            var newTeacher = _teacherData.GetById(int.Parse(model.SelectedTeacher));
            if (newTeacher is null)
                return BadRequest();

            var newStudent = _studentData.GetById(int.Parse(model.SelectedStudent));
            if (newStudent is null)
                return BadRequest();

            var newSubject = _subjectData.GetById(int.Parse(model.SelectedSubject));
            if (newSubject is null)
                return BadRequest();

            lesson.DateTime = model.Date;
            lesson.Direction = model.Direction;
            lesson.Teacher = newTeacher;
            lesson.Subject = newSubject;
            lesson.Student = newStudent;

            if (model.LessonId == 0) // или добавляем 
                _lessonsData.Add(lesson);

            else if (!_lessonsData.Edit(lesson)) // или редактируем
                return NotFound();

            #region Warning!
            //Для работы с памятью это можно убрать(так как мы ссылку получаем)
            //Когда будешь работать с БД, логику надо поменять


            //if (!_lessonsData.Edit(lesson))
            //    return NotFound();
            #endregion

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();

            var lesson = _lessonsData.GetById(id);
            if (lesson is null)
                return NotFound();

            var model = new Lesson
            {
                Id = lesson.Id,
                DateTime = lesson.DateTime,
                Subject = lesson.Subject,
                Direction = lesson.Direction,
                Teacher = lesson.Teacher,
                Student = lesson.Student,
            };

            return View(model);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var lesson = _lessonsData.GetById(id);
            if (lesson is null)
                return NotFound();

            _lessonsData.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
