using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdminAPI.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Registration> Registrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.StudentRegistrations)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Teacher)
                .WithMany(c => c.StudentRegistrations)
                .HasForeignKey(bc => bc.TeacherId);
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Email = "teacherken@gmail.com" },
                new Teacher { Id = 2, Email = "teacherjoe@gmail.com" },
                new Teacher { Id = 3, Email = "teachershaun@gmail.com" }
                );
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Email = "studentjon@gmail.com", Status = StudentStatus.Active  },
                new Student { Id = 2, Email = "studenthon@gmail.com", Status = StudentStatus.Active },
                new Student { Id = 3, Email = "studentmary@gmail.com", Status = StudentStatus.Active },
                new Student { Id = 4, Email = "studentbob@gmail.com", Status = StudentStatus.Active },
                new Student { Id = 5, Email = "studentagnes@gmail.com", Status = StudentStatus.Active },
                new Student { Id = 6, Email = "studentmiche@gmail.com", Status = StudentStatus.Active }
                );
        }
    }
}
