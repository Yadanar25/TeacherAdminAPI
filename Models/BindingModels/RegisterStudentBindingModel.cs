using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdminAPI.Models.BindingModels
{
    public class RegisterStudentBindingModel
    {
        public string Teacher { get; set; }
        public string[] Students { get; set; }
    }
}
