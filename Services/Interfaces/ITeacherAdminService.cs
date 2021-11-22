using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdminAPI.Models.BindingModels;
using TeacherAdminAPI.Models.ResultModel;
using TeacherAdminAPI.Models.ViewModels;

namespace TeacherAdminAPI.Services.Interfaces
{
    public interface ITeacherAdminService
    {
        Task<ServiceResult<bool>> RegisterStudents(RegisterStudentBindingModel model);

        Task<ServiceResult<StudentsListViewModel>> GetCommonStudentsList(string[] teacher);

        Task<ServiceResult<bool>> SuspendStudent(SuspendStudentBindingModel model);

        Task<ServiceResult<NotiRecipientListViewModel>> RetrieveStudentsForNoti(NotificationStudentListBindingModel model);
    }
}
