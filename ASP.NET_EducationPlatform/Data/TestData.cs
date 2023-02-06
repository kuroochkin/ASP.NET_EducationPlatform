using EducationPlatfotm.Domain.Users;

namespace ASP.NET_EducationPlatform.Data
{
    public static class TestData
    {
        public static List<Teacher> teachers { get; } = new()
        {
            new Teacher {Id = 1, LastName = "Келин", FirstName = "Кирилл", Patronymic = "Вячеславович"},
            new Teacher {Id = 2, LastName = "Курочкин", FirstName = "Владислав", Patronymic = "Романович"},
        };

    }
}
