using Microsoft.Extensions.DependencyInjection;
using Sidus.DotNet.Application.Services.System;
using Sidus.DotNet.Application.Services.Test;
using Sidus.DotNet.Core.Contracts.Services.Action;
using Sidus.DotNet.Core.Contracts.Services.Test;

namespace Sidus.DotNet.Application
{
    public static class StartupSetup
    {
        public static void RegisterServices(this IServiceCollection services) =>
            services.AddScoped<ITestService, TestService>()
            .AddScoped<IActionService, ActionService>();
    }
}
