using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdminAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public ICollection<Registration> StudentRegistrations { get; set; }
    }
}
