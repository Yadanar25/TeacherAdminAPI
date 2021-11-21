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
            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.StudentRegistrations)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<Registration>()
                .HasOne(bc => bc.Teacher)
                .WithMany(c => c.StudentRegistrations)
                .HasForeignKey(bc => bc.TeacherId);
        }
    }
}
