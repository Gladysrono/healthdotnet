using newhealthdiotnet.Contracts.Authentication;

namespace newhealthdotnet.Application.Services
{
    public class AuthenticationServiceBase
    {

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (!(user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)))
            {
                throw new Exception("Invalid credentials");
            }

            // var token = _jwtTokenGenerator.GenerateToken(user);

            //  return new AuthenticationResponse { Token = token };
        }
    }
}