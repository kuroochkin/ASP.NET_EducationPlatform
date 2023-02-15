using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.InMemory
{
    public class InMemorySubjectData : ISubjectData
    {
        private ICollection<Subject> _subjects;

        public InMemorySubjectData()
        {
            _subjects = TestData.subjects;
        }

        public Subject? GetById(int id)
        {
            return _subjects.FirstOrDefault(s => s.Id == id);
        }
    }
}
