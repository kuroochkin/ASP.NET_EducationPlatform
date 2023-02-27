using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatform.DAL;
using EducationPlatfotm.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_EducationPlatform.Services.InSQL
{
    public class SqlStudentsData : IStudentData
    {
        private readonly EducationPlatformDB _db;
        private readonly ILogger<SqlTeachersData> _Logger;

        public SqlStudentsData(EducationPlatformDB db, ILogger<SqlTeachersData> Logger)
        {
            _db = db;
            _Logger = Logger;
        }
        public int Add(Student student)
        {
            _db.Entry(student).State = EntityState.Added;

            _db.SaveChanges(); // только здесь employee.Id получит значение

            return student.Id;
        }

        public bool Delete(int id)
        {
            var student = _db.Students.Find(id);

            if (student is null)
                return false;

            
            _db.Students.Remove(student);

            _db.SaveChanges();
            return true;
        }

        public bool Edit(Student student)
        {
            _db.Students.Update(student);

            return _db.SaveChanges() != 0;
        }

        public IEnumerable<Student> GetAllStudents() => _db.Students.AsEnumerable();


        public Student? GetById(int id)
        {
            return _db.Students.Find(id);
        }
    }
}
