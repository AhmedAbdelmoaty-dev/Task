namespace Application.Exceptions
{
    public class ForbiddenException:AppException
    {
        public ForbiddenException(string message="Access Forbidden") : base(403, message) { }
    }
}
