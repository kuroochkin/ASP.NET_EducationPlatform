using EducationPlatfotm.Domain;

namespace ASP.NET_EducationPlatform.Services.Interfaces
{
    public interface ISubjectData
    {
        public Subject? GetById(int id);
    }
}
