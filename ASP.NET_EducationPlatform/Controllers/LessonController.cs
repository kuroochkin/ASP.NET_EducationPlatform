using ASP.NET_EducationPlatform.Services.Interfaces;
using ASP.NET_EducationPlatform.ViewModels;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_EducationPlatform.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonData _lessonsData;

        public LessonController(ILessonData lessonData)
        {
            _lessonsData = lessonData;
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

            var model = new LessonViewModel()
            {
                DateTime = lesson.DateTime,
                Subject = lesson.Subject,
                Direction = lesson.Direction,
                Teacher = lesson.Teacher,
                Students = lesson.Students,
            };

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
