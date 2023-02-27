using ASP.NET_EducationPlatform.Data;
using ASP.NET_EducationPlatform.Services.Interfaces;
using EducationPlatform.DAL;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_EducationPlatform.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly EducationPlatformDB _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(EducationPlatformDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken Cancel = default)
        {
            if (RemoveBefore)
                await RemoveAsync(Cancel).ConfigureAwait(false);

            //await _db.Database.EnsureCreatedAsync();

            var pending_migrations = await _db.Database.GetPendingMigrationsAsync(Cancel);
            if(pending_migrations.Any())
            {
                await _db.Database.MigrateAsync(Cancel).ConfigureAwait(false);
            }

            await InitializeTeachersAsync(Cancel).ConfigureAwait(false);
            await InitializeStudentsAsync(Cancel).ConfigureAwait(false);
            await InitializeLessonsAsync(Cancel).ConfigureAwait(false);
            await InitializeSubjectsAsync(Cancel).ConfigureAwait(false);
        }

        private async Task InitializeTeachersAsync(CancellationToken Cancel)
        {
            if (await _db.Teachers.AnyAsync(Cancel))
            {
                _Logger.LogInformation("Инициализация учителей не требуется");
                return;
            }

            _Logger.LogInformation("Инициализация учителей...");
            await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

            TestData.teachers.ForEach(teacher => teacher.Id = 0);

            await _db.Teachers.AddRangeAsync(TestData.teachers, Cancel);
            await _db.SaveChangesAsync(Cancel);

            await transaction.CommitAsync(Cancel);
            _Logger.LogInformation("Инициализация учителей выполнена успешно");
        }

        private async Task InitializeStudentsAsync(CancellationToken Cancel = default)
        {
            if (await _db.Students.AnyAsync(Cancel))
            {
                _Logger.LogInformation("Инициализация студентов не требуется");
                return;
            }

            _Logger.LogInformation("Инициализация студентов...");
            await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

            TestData.students.ForEach(student => student.Id = 0);

            await _db.Students.AddRangeAsync(TestData.students, Cancel);
            await _db.SaveChangesAsync(Cancel);

            await transaction.CommitAsync(Cancel);
            _Logger.LogInformation("Инициализация студентов выполнена успешно");
        }

        private async Task InitializeLessonsAsync(CancellationToken Cancel = default)
        {
            if (await _db.Lessons.AnyAsync(Cancel))
            {
                _Logger.LogInformation("Инициализация уроков не требуется");
                return;
            }

            _Logger.LogInformation("Инициализация уроков...");
            await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

            TestData.lessons.ForEach(lesson => lesson.Id = 0);

            await _db.Lessons.AddRangeAsync(TestData.lessons, Cancel);
            await _db.SaveChangesAsync(Cancel);

            await transaction.CommitAsync(Cancel);
            _Logger.LogInformation("Инициализация уроков выполнена успешно");
        }

        private async Task InitializeSubjectsAsync(CancellationToken Cancel = default)
        {
            if (await _db.Subjects.AnyAsync(Cancel))
            {
                _Logger.LogInformation("Инициализация уроков не требуется");
                return;
            }

            _Logger.LogInformation("Инициализация уроков...");
            await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

            TestData.subjects.ForEach(lesson => lesson.Id = 0);

            await _db.Subjects.AddRangeAsync(TestData.subjects, Cancel);
            await _db.SaveChangesAsync(Cancel);

            await transaction.CommitAsync(Cancel);
            _Logger.LogInformation("Инициализация уроков выполнена успешно");
        }


        public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
        {
            return await _db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);
        }

        
    }
}
