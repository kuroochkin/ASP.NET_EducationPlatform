using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatform.DAL;
using EducationPlatfotm.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_EducationPlatform.Services.InSQL
{
    public class SqlLessonsData : ILessonData
    {

        private readonly EducationPlatformDB _db;
        private readonly ILogger<SqlLessonsData> _Logger;

        public SqlLessonsData(EducationPlatformDB db, ILogger<SqlLessonsData> Logger)
        {
            _db = db;
            _Logger = Logger;
        }
        public int Add(Lesson lesson)
        {
            _db.Entry(lesson).State = EntityState.Added;

            _db.SaveChanges(); // только здесь employee.Id получит значение

            return lesson.Id;
        }

        public bool Delete(int id)
        {
            var lesson = _db.Lessons.Find(id);

            if (lesson is null)
                return false;

            _db.Lessons.Remove(lesson);

            _db.SaveChanges();
            return true;
        }

        public bool Edit(Lesson lesson)
        {
            _db.Lessons.Update(lesson);

            return _db.SaveChanges() != 0;
        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            return _db.Lessons.AsEnumerable();
        }

        public Lesson? GetById(int id)
        {
            return _db.Lessons.Find(id);
        }
    }
}
