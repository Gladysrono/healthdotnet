using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using newhealthdiotnet.Contracts.Authentication;
using LoginRequest = newhealthdiotnet.Contracts.Authentication.LoginRequest;
using RegisterRequest = newhealthdiotnet.Contracts.Authentication.RegisterRequest;

namespace newhealthdotnet.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
        Task<AuthenticationResponse> LoginAsync(LoginRequest request);
        Task ForgetPasswordAsync(ForgetPassword request);
        Task ResetPasswordAsync(ResetPassword request);
    }
}
