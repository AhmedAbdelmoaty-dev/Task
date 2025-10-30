namespace Application.Exceptions
{
    public class NotFoundException:AppException
    {
        public NotFoundException(string message="resourse was not found") : base(404, message) { }
    }
}
