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

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EditLessonViewModel());

            var lesson = _lessonsData.GetById((int)id);
            if (lesson is null)
                return NotFound();

            var teachers = _teacherData.GetAllTeachers();

            var model = new EditLessonViewModel()
            {
                LessonId = lesson.Id,
                Date = lesson.DateTime,
                Direction = lesson.Direction,
                TeacherFullName = lesson.Teacher.FIO,
                Selected = lesson.Teacher.Id.ToString(),
            };

            foreach (var teacher in teachers)
            {
                model.TeacherSelectList.Add(new SelectListItem
                {
                    Text = teacher.FIO,
                    Value = Convert.ToString(teacher.Id),
                });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditLessonViewModel model)
        {
            if (model == null || !ModelState.IsValid)
                return NotFound();

            var lesson = _lessonsData.GetById(model.LessonId);

            if (lesson is null)
                return BadRequest();

            var newTeacher = _teacherData.GetById(int.Parse(model.Selected));
            if (newTeacher is null)
                return BadRequest();

            lesson.DateTime = model.Date;
            lesson.Direction = model.Direction;
            lesson.Teacher = newTeacher;

            #region Warning!
            //Для работы с памятью это можно убрать(так как мы ссылку получаем)
            //Когда будешь работать с БД, логику надо поменять


            //if (!_lessonsData.Edit(lesson))
            //    return NotFound();
            #endregion

            ViewBag.Value = lesson.Teacher.Id;
            ViewBag.Text = lesson.Teacher.FIO;

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
