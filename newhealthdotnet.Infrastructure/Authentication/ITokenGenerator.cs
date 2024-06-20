using newhealthdotnet.Domain.Entities;

namespace newhealthdotnet.Infrastructure.Authentication
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
