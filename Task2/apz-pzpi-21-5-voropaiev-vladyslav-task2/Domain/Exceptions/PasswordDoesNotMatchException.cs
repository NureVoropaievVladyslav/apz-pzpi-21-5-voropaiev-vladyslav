namespace Domain.Exceptions;

public class PasswordDoesNotMatchException() : ExceptionBase("Password does not match.", HttpStatusCode.Unauthorized);