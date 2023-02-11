using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.InMemory
{
    public class InMemoryStudentData : IStudentData
    {
        private ICollection<Student> _students;

        private int _MaxFreeId; // Максимальный свободный ID

        public InMemoryStudentData()
        {
            _students = TestData.students;
            _MaxFreeId = _students.DefaultIfEmpty().Max(e => e?.Id ?? 0);
        }

        public int Add(Student student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            if (_students.Contains(student))
                return student.Id;

            student.Id = ++_MaxFreeId;
            _students.Add(student);
            return student.Id;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student is null)
                return false;

            _students.Remove(student);
            return true;
        }

        public bool Edit(Student student)
        {
            if (student is null)
                throw new ArgumentNullException(nameof(student));

            if (_students.Contains(student))
                return false;

            var db_student = GetById(student.Id);
            if (db_student is null)
                throw new ArgumentNullException(nameof(db_student));

            db_student.FirstName = student.FirstName;
            db_student.LastName = student.LastName;
            db_student.Patronymic = student.Patronymic;
            db_student.YearStudy = student.YearStudy;
            db_student.Subjects = student.Subjects;

            return true;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student? GetById(int id)
        {
            return _students.FirstOrDefault(t => t.Id == id);
        }

    }
}
