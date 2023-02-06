﻿using ASP.NET_EducationPlatform.Services.Interfaces;
using ASP.NET_EducationPlatform.ViewModels;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Mapping;

namespace ASP.NET_EducationPlatform.Controllers
{
    public class TeacherController : Controller
    {
        public ITeacherData _teachers { get; set; } // Свойство для хранения сотрудников в контроллере через сервис
        public TeacherController(ITeacherData TeachersData)
        {
            _teachers = TeachersData; // Получаем данные по сотрудникам из класса TestData
        }
        public IActionResult Index()
        {
            var teachers = _teachers.GetAllTeachers();
            return View(teachers);
        }

        public IActionResult Details(int id)
        {
            var teacher = _teachers.GetById(id);

            if (teacher is null)
                return NotFound();

            return View(teacher);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new TeacherViewModel());


            var teacher = _teachers.GetById((int)id);
            if (teacher is null)
                return NotFound();

            var model = new TeacherViewModel
            {
                Id = teacher.Id,
                LastName = teacher.LastName,
                FirstName = teacher.FirstName,
                Patronymic = teacher.Patronymic,
                Speciality = teacher.Subject.Name,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TeacherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var teacher = new Teacher
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                Subject = new Subject { Name = model.Speciality }
            };

            if(!_teachers.Edit(teacher))
                return NotFound();

            return RedirectToAction("Index");
        }
    }
}
