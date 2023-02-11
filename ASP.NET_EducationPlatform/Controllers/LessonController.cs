using ASP.NET_EducationPlatform.Services.Interfaces;
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

        public IActionResult Edit(int id)
        {
            var lesson = _lessonsData.GetById(id);
            if (lesson is null)
                return NotFound();

            return View(lesson);
        }
    }
}
