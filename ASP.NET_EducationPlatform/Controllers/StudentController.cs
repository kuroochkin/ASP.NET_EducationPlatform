using ASP.NET_EducationPlatform.Services.Interfaces;
using ASP.NET_EducationPlatform.ViewModels;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_EducationPlatform.Controllers
{
    public class StudentController : Controller
    {
        public IStudentData _students { get; set; } // Свойство для хранения учеников в контроллере через сервис
        public StudentController(IStudentData StudentsData)
        {
            _students = StudentsData; // Получаем данные по ученикам из класса TestData
        }
        public IActionResult Index()
        {
            var students = _students.GetAllStudents();
            return View(students);
        }
        public IActionResult Details(int id)
        {
            var student = _students.GetById(id);

            if (student is null)
                return NotFound();

            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new StudentViewModel());

            var student = _students.GetById((int)id);
            if (student is null)
                return NotFound();

            var model = new StudentViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Patronymic = student.Patronymic,
                YearStudy = student.YearStudy,
                Speciality = student.Subjects,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var student = new Student
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                YearStudy = model.YearStudy,
                Subjects = model.Speciality,
            };

            if (model.Id == 0) // или добавляем 
                _students.Add(student);

            else if (!_students.Edit(student)) // или редактируем
                return NotFound();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();

            var student = _students.GetById(id);
            if (student is null)
                return NotFound();

            var model = new StudentViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Patronymic = student.Patronymic,
                YearStudy = student.YearStudy,
                Speciality = student.Subjects,
            };

            return View(model);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var student = _students.GetById(id);
            if (student is null)
                return NotFound();

            _students.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
