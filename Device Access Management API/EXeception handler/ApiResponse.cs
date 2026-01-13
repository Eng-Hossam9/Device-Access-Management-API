using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_Access_Management_API.ExecptionHandler
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(T data, bool success = true, string message = "")
        {
            Data = data;
            Success = success;
            Message = message;
        }
    }

}
