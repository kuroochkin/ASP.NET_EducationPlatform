using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.Interfaces
{
    public interface ILessonData
    {
        IEnumerable<Lesson> GetAllLessons();
        Lesson? GetById(int id);
        bool Edit(Lesson lesson);
        bool Delete(int id);
        int Add(Lesson lesson);
    }
}
