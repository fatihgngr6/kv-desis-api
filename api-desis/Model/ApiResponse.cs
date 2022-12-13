using System;
namespace api_desis.Model
{
    public class ApiResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object? ResponseData { get; set; }

        public enum ResponseType
        {
            Success,
            NotFound,
            Failure
        }
        public ApiResponse()
        {
        }
    }
}

