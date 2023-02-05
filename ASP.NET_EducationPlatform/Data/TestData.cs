using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Data
{
    public static class TestData
    {
        public static List<Teacher> teachers { get; } = new()
        {
            new Teacher {LastName = "Келин", FirstName = "Кирилл", Patronymic = "Вячеславович"},
            new Teacher {LastName = "Курочкин", FirstName = "Владислав", Patronymic = "Романович"},
        };

    }
}
