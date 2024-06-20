using newhealthdotnet.Domain.Entities.UserManagement;

namespace newhealthdotnet.Infrastructure.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
