using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.Interfaces
{
    public interface ITeacherData
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher? GetById(int id);
        bool Edit(Teacher teacher);
        bool Delete(int id);
        int Add(Teacher teacher);
    }
}
