using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatform.DAL;
using EducationPlatfotm.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_EducationPlatform.Services.InSQL
{
    public class SqlTeachersData : ITeacherData
    {
        private readonly EducationPlatformDB _db;
        private readonly ILogger<SqlTeachersData> _Logger;

        public SqlTeachersData(EducationPlatformDB db, ILogger<SqlTeachersData> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public int Add(Teacher teacher)
        {
            _db.Entry(teacher).State = EntityState.Added;

            _db.SaveChanges();

            return teacher.Id;
        }

        public bool Delete(int id)
        {
            var teacher = _db.Teachers.Find(id);

            if (teacher is null)
                return false;

            
            _db.Teachers.Remove(teacher);

            _db.SaveChanges();
            return true;
        }

        public bool Edit(Teacher teacher)
        {
            _db.Teachers.Update(teacher);

            _db.SaveChanges();

            return _db.SaveChanges() != 0;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _db.Teachers.AsEnumerable();
        }

        public Teacher? GetById(int id)
        {
            return _db.Teachers.Find(id);
        }
    }
}
