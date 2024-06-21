namespace newhealthdotnet.Infrastructure.Repositories
{
    public interface IEmailSender
    {
        Task SendResetPasswordEmailAsync(string email, string token);
    }
}
