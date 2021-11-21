using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdminAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public StudentStatus Status { get; set; }
        public ICollection<Registration> StudentRegistrations { get; set; }
    }

    public enum StudentStatus
    {
        Active,
        Suspended
    }
}
