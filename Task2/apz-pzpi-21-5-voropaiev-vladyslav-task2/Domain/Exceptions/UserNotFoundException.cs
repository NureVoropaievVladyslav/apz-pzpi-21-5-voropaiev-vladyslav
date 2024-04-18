namespace Domain.Exceptions;

public class UserNotFoundException()
    : ExceptionBase("User with such credentials does not exist.", HttpStatusCode.NotFound);