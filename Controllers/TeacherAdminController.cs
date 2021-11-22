using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherAdminAPI.Models.BindingModels;
using TeacherAdminAPI.Services.Interfaces;

namespace TeacherAdminAPI.Controllers
{
    /// <summary>
    /// TeacherAdminApi
    /// </summary>
    [ApiController]
    [Route("api")]
    public class TeacherAdminController : ControllerBase
    {
        private ITeacherAdminService _teacherStudentService;

        public TeacherAdminController(ITeacherAdminService teacherStudentService)
        {
            _teacherStudentService = teacherStudentService;
        }

        /// <summary>
        /// Register Student
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentBindingModel model)
        {
            var result = await _teacherStudentService.RegisterStudents(model);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest(new { message = result.Message });
        }

        /// <summary>
        /// Retrieve Common Students List who register under all teachers from input parameter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("commonstudents")]
        public async Task<IActionResult> GetCommonStudentsList()
        {
            try
            {
                var teacher = Request.Query["teacher"];
                var result =await _teacherStudentService.GetCommonStudentsList(teacher);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(new { message = result.Message });                
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Suspend Student
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("suspend")]
        public async Task<IActionResult> SuspendStudent(SuspendStudentBindingModel model)
        {
            try
            {
                var result = await _teacherStudentService.SuspendStudent(model);
                if (result.Success)
                {
                    return NoContent();
                }
                return BadRequest(new { message = result.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Retrieve a list of students who can receive a given notification
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("retrievefornotifications")]
        public async Task<IActionResult> RetrieveListofStudentForNotification(NotificationStudentListBindingModel model)
        {
            try
            {
                var result = await _teacherStudentService.RetrieveStudentsForNoti(model);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(new { message = result.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


    }
}
