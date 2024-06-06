using newhealthdotnet.Domain.Entities;

namespace newhealthdotnet.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}