using System;
namespace BackEnd.Models
{
    public class ResponseModel<T>
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
