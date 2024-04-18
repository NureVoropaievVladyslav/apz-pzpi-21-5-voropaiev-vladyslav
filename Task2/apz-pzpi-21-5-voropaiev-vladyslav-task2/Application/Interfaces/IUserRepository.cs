namespace Application.Interfaces;

public interface IUserRepository
{
    Task<string> LoginAsync(string login, string password, CancellationToken cancellationToken);
    
    Task<string> RegisterUserAsync(User user, string password, CancellationToken cancellationToken);
}