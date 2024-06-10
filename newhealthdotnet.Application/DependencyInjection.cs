using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Application.Services;
using newhealthdotnet.Application.Commands;
using newhealthdotnet.Application.Handlers;
using newhealthdotnet.Application.Validators;
using newhealthdotnet.Infrastructure.Authentication;
using newhealthdotnet.Infrastructure.Repositories;
using System.Reflection;

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
            services.AddScoped<JwtTokenGenerator>();

            return services;
        }
    }
}
