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
        }

        private async Task InitializeTeachersAsync(CancellationToken Cancel = default)
        {
            if (_db.Teachers.Any())
                return;

            await using (await _db.Database.BeginTransactionAsync(Cancel))
            {
                await _db.Teachers.AddRangeAsync(TestData.teachers, Cancel);

                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Teachers] ON", Cancel);
                await _db.SaveChangesAsync(Cancel);
                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Teachers] OFF", Cancel);

                await _db.Database.CommitTransactionAsync(Cancel);
            }
        }

        private async Task InitializeStudentsAsync(CancellationToken Cancel = default)
        {
            if (_db.Students.Any())
                return;

            await using (await _db.Database.BeginTransactionAsync(Cancel))
            {
                await _db.Students.AddRangeAsync(TestData.students, Cancel);

                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Students] ON", Cancel);
                await _db.SaveChangesAsync(Cancel);
                await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Students] OFF", Cancel);

                await _db.Database.CommitTransactionAsync(Cancel);
            }
        }

        public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
        {
            return await _db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);
        }

        
    }
}
