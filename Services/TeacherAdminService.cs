using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeacherAdminAPI.Models;
using TeacherAdminAPI.Models.BindingModels;
using TeacherAdminAPI.Models.ResultModel;
using TeacherAdminAPI.Models.ViewModels;
using TeacherAdminAPI.Services.Interfaces;

namespace TeacherAdminAPI.Services
{
    public class TeacherAdminService : ITeacherAdminService
    {
        private ApplicationDBContext _dbContext;
        public TeacherAdminService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<bool>> RegisterStudents(RegisterStudentBindingModel model)
        {
            var retrieveTeacherId = _dbContext.Teachers.Where(x => x.Email == model.Teacher).Select(x => x.Id).FirstOrDefault();
            if(retrieveTeacherId == 0)
            {
                return new ServiceResult<bool>("The teacher email is not found!!!");
            }
            var retrieveStudentsId = _dbContext.Students.Where(x => model.Students.Contains(x.Email)).Select(x => x.Id).Distinct().ToArray();
            if(retrieveStudentsId != null)
            {
                foreach(int id in retrieveStudentsId)
                {
                    if(!_dbContext.Registrations.Any(x => x.StudentId == id && x.TeacherId == retrieveTeacherId))
                    {
                        var temp = new Registration();
                        temp.StudentId = id;
                        temp.TeacherId = retrieveTeacherId;
                        _dbContext.Registrations.Add(temp);
                    }
                }
                _dbContext.SaveChanges();
            }
            return new ServiceResult<bool>();
        }

        public async Task<ServiceResult<StudentsListViewModel>> GetCommonStudentsList(string[] teacher)
        {
            var checkTeachers = _dbContext.Teachers.Where(x => teacher.Contains(x.Email)).Count() == teacher.Count();
            if (!checkTeachers)
            {
                return new ServiceResult<StudentsListViewModel>("One or more teacher's email is not found!!!");
            }
            List<string> retrieveStudentList = new List<string>();
            var getStudents = _dbContext.Registrations.Where(x => teacher.Contains(x.Teacher.Email)).Select(x => x.Student.Email).ToList();
            List<string> getCommonStudents = getStudents.GroupBy(x => x)
                                        .Where(g => g.Count() == teacher.Count())
                                        .Select(x => x.Key).ToList();
            StudentsListViewModel studentList = new StudentsListViewModel()
            {
                Students = getCommonStudents.ToArray()
            };
            return new ServiceResult<StudentsListViewModel>(studentList);
        }

        public async Task<ServiceResult<bool>> SuspendStudent(SuspendStudentBindingModel model)
        {
            var student = _dbContext.Students.Where(x => x.Email == model.Student).FirstOrDefault();
            if(student != null)
            {
                if(student.Status == StudentStatus.Suspended)
                {
                    return new ServiceResult<bool>("The student is already suspended!!!");
                }
                student.Status = StudentStatus.Suspended;

                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
                return new ServiceResult<bool>();
            }
            return new ServiceResult<bool>("The student email is not found!!!");
        }

        public async Task<ServiceResult<NotiRecipientListViewModel>> RetrieveStudentsForNoti(NotificationStudentListBindingModel model)
        {
            var getTeacherId = _dbContext.Teachers.Where(x => x.Email == model.Teacher).Select(x => x.Id).FirstOrDefault();
            if(getTeacherId == 0)
            {
                return new ServiceResult<NotiRecipientListViewModel>("The teacher is not in the list");
            }
            var getStudentEmailFromModel = ExtractEmails(model.Notification);
            var getStudentEmails = _dbContext.Registrations.Where(x => x.TeacherId == getTeacherId
                                    && x.Student.Status != StudentStatus.Suspended).Select(x => x.Student.Email)
                                    .Distinct().ToList();
            var checkEmailFromModel = _dbContext.Students.Where(x => getStudentEmailFromModel.Contains(x.Email)
                                        && x.Status != StudentStatus.Suspended).Select(x => x.Email).Distinct().ToList();
            getStudentEmails.AddRange(checkEmailFromModel);
            var getAllRecipient = getStudentEmails.Distinct();
            NotiRecipientListViewModel studentList = new NotiRecipientListViewModel()
            {
                Recipients = getAllRecipient.ToArray()
            };
            return new ServiceResult<NotiRecipientListViewModel>(studentList);
        }

        //For retrieving email from text
        public List<string> ExtractEmails(string textToScrape)
        {
            Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            Match match;

            List<string> results = new List<string>();
            for (match = reg.Match(textToScrape); match.Success; match = match.NextMatch())
            {
                if (!(results.Contains(match.Value)))
                    results.Add(match.Value.ToLower());
            }

            return results;
        }
    }
}
