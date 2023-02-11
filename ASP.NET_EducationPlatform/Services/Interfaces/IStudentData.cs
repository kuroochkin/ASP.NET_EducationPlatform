using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Services.Interfaces
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAllStudents();
        Student? GetById(int id);
        bool Edit(Student student);
        bool Delete(int id);
        int Add(Student student);
    }
}
