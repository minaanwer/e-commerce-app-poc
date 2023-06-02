using Microsoft.AspNetCore.Mvc;

namespace SKINET.Error
{
    public class ApiResponse  
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message??GetDefaultMessageForStatusCode(this.StatusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "a bad Request,you have made",
                401 => "authorized , you are not autorized to do this action",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public String Message { get; set; }
    }
}
