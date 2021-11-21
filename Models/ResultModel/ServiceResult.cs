using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherAdminAPI.Models.ResultModel
{
    public class ServiceResult<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }

        public ServiceResult()
        {
            Success = true;
        }

        public ServiceResult(T data)
        {
            Success = true;
            Data = data;
        }

        public ServiceResult(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
