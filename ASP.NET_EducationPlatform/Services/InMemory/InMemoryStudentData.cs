using ASP.NET_EducationPlatform.Data;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.InMemory
{
    public class InMemoryStudentData
    {
        private ICollection<Student> _students;

        private int _MaxFreeId; // Максимальный свободный ID

        public InMemoryStudentData()
        {
            _students = TestData.students;
            _MaxFreeId = _students.DefaultIfEmpty().Max(e => e?.Id ?? 0);
        }
    }
}
