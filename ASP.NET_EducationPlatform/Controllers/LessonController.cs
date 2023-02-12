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

        public LessonController(ILessonData lessonData, ITeacherData teacherData)
        {
            _lessonsData = lessonData;
            _teacherData = teacherData;
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

        public IActionResult Edit(int id)
        {
            var lesson = _lessonsData.GetById(id);
            if (lesson is null)
                return NotFound();

            var teachers = _teacherData.GetAllTeachers();

            var model = new LessonViewModel()
            {
                Id = lesson.Id,
                DateTime = lesson.DateTime,
                Subject = lesson.Subject,
                Direction = lesson.Direction,
                Teacher = lesson.Teacher,
                Students = lesson.Students,
            };

            foreach(var teacher in teachers)
            {
                model.TeacherSelectList.Add(teacher);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(LessonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            

            var lesson = new Lesson()
            {
                Id = model.Id,
                DateTime = model.DateTime,
                Subject = model.Subject,
                Direction = model.Direction,
                Teacher = model.Teacher,
                Students = model.Students,
            };

            if (lesson is null)
                return NotFound();

            if(!_lessonsData.Edit(lesson))
                return NotFound();

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
                Students = lesson.Students,
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
