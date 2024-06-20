using newhealthdotnet.Domain.Entities.UserManagement;

namespace newhealthdotnet.Infrastructure.Authentication.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}