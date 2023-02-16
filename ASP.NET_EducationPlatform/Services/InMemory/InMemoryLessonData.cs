using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.InMemory
{
    public class InMemoryLessonData : ILessonData
    {
        private ICollection<Lesson> _lessons;
        private int _MaxFreeId;

        public InMemoryLessonData()
        {
            _lessons = TestData.lessons;
            _MaxFreeId = _lessons.DefaultIfEmpty().Max(e => e?.Id ?? 0);
        }

        public int Add(Lesson lesson)
        {
            if (lesson is null)
                throw new ArgumentNullException();

            if (_lessons.Contains(lesson))
                return lesson.Id;

            lesson.Id = ++_MaxFreeId;

            _lessons.Add(lesson);

            return lesson.Id;
        }

        public bool Delete(int id)
        {
            var lesson = GetById(id);
            if (lesson is null)
                return false;

            _lessons.Remove(lesson);
            return true;
        }

        public bool Edit(Lesson lesson)
        {
            if (lesson is null)
                throw new ArgumentNullException(nameof(lesson));

            if (_lessons.Contains(lesson))
                return false;

            var db_lesson = GetById(lesson.Id);
            if (db_lesson is null)
                throw new ArgumentNullException(nameof(db_lesson));

            db_lesson.Id = lesson.Id;
            db_lesson.Subject = lesson.Subject;
            db_lesson.Teacher = lesson.Teacher;
            db_lesson.Direction = lesson.Direction;
            db_lesson.Student = lesson.Student;
            db_lesson.DateTime = lesson.DateTime;
            db_lesson.FIOTeacher = lesson.FIOTeacher;


            return true;
        }

        public IEnumerable<Lesson> GetAllLessons()
        {
            return _lessons;
        }

        public Lesson? GetById(int id)
        {
            return _lessons.FirstOrDefault(l => l.Id == id);
        }

        
    }
}
