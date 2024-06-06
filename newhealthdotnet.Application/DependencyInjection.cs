using Microsoft.Extensions.DependencyInjection;
using newhealthdotnet.Application.Interfaces;
using newhealthdotnet.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newhealthdotnet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            _ = services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
