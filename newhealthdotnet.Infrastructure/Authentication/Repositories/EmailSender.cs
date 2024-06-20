namespace newhealthdotnet.Infrastructure.Authentication.Repositories
{
    public class EmailSender : IEmailSender
    {
        public async Task SendResetPasswordEmailAsync(string email, string token)
        {
            // Implement your email sending logic here
            await Task.CompletedTask;
        }
    }
}
