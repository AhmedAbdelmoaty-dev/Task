using System.Runtime.CompilerServices;

namespace Application.Exceptions
{
    public class AppException:Exception
    {
        public int StatusCode { get; init; }
        public AppException(int statusCode,string Message):base(Message)
        {
            StatusCode = statusCode;
        }
    }
}
