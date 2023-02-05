using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.InMemory
{
    public class InMemoryTeacherData : ITeacherData
    {
        private ICollection<Teacher> _teachers;

        private int _MaxFreeId; // Максимальный свободный ID

        public InMemoryTeacherData()
        {
            _teachers = TestData.teachers;
            _MaxFreeId = _teachers.DefaultIfEmpty().Max(e => e?.Id ?? 0);
        }

        public int Add(Teacher teacher)
        {
            if(teacher is null)
                throw new ArgumentNullException(nameof(teacher));

            if (_teachers.Contains(teacher))
                return teacher.Id;

            teacher.Id = ++_MaxFreeId;
            _teachers.Add(teacher);
            return teacher.Id;
        }

        public bool Delete(int id)
        {
            var teacher = GetById(id);
            if (teacher is null)
                return false;

            _teachers.Remove(teacher);
            return true;
        }

        public bool Edit(Teacher teacher)
        {
            if (teacher is null)
                throw new ArgumentNullException(nameof(teacher));

            if (_teachers.Contains(teacher)) 
                return false;

            var db_teacher = GetById(teacher.Id);
            if(db_teacher is null)
                throw new ArgumentNullException(nameof(db_teacher));

            return true;

           
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        public Teacher? GetById(int id)
        {
            return _teachers.FirstOrDefault(t => t.Id == id);
        }
    }
}
