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
    [ApiController]
    [Route("api")]
    public class TeacherStudentController : ControllerBase
    {
        private ITeacherStudentService _teacherStudentService;

        public TeacherStudentController(ITeacherStudentService teacherStudentService)
        {
            _teacherStudentService = teacherStudentService;
        }

        /// <summary>
        /// Register Student
        /// </summary>
        /// <param name="model">The model.</param>
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
