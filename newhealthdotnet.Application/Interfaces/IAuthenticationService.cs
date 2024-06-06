using newhealthdiotnet.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newhealthdotnet.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
        Task<AuthenticationResponse> LoginAsync(LoginRequest request);
        



    }
}
