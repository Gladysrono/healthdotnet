namespace newhealthdotnet.Infrastructure.Authentication.Repositories
{
    public interface IEmailSender
    {
        Task SendResetPasswordEmailAsync(string email, string token);
    }
}
