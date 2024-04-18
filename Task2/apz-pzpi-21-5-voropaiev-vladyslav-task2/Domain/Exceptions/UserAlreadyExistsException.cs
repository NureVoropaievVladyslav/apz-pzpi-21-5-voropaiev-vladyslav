namespace Domain.Exceptions;

public class UserAlreadyExistsException()
    : ExceptionBase("User with such credentials already exists", HttpStatusCode.Conflict);