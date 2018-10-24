namespace Zanella.MF7.Dominio.Exceptions
{
    public class InvalidCredentialsException : BusinessException
    {
        public InvalidCredentialsException() : base(ErrorCodes.Unauthorized, "The user name or password is incorrect") { }
    }
}
