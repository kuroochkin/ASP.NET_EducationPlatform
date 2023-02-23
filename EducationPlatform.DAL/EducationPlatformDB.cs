using EducationPlatfotm.Domain;
using EducationPlatfotm.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.DAL
{
    public class EducationPlatformDB : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public EducationPlatformDB(DbContextOptions<EducationPlatformDB> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder db)
        {
            base.OnModelCreating(db);
        }
    }
}
