namespace Application.Exceptions
{
    public class BadRequestException:AppException
    {
        public IDictionary<string, string[]> Errors { get; init; }
        public BadRequestException(string Message="Bad Request", IDictionary<string, string[]>errors=null) : base(400, Message) { 
            Errors= errors; 
        }

    }
}
