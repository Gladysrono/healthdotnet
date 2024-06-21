using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Application.Services;
using newhealthdotnet.Infrastructure.Authentication;
using System.Reflection;
using newhealthdotnet.Application.Authentication.CommandsAndQueris.Commands.Register;
using newhealthdotnet.Infrastructure.Repositories;

namespace newhealthdotnet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            // Register MediatR services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register FluentValidation validators
            services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();

            // Register other infrastructure services
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<JwtTokenGenerator>();

            return services;
        }
    }
}
