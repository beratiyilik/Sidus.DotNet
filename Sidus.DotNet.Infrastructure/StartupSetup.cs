using Microsoft.Extensions.DependencyInjection;
using Sidus.DotNet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Sidus.DotNet.Infrastructure.Repositories.Test;
using Sidus.DotNet.Infrastructure.Repositories.System;
using MediatR;
using Sidus.DotNet.Core.Contracts.Repositories.System;
using Sidus.DotNet.Core.Contracts.Repositories.Test;

namespace Sidus.DotNet.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root


        public static void RegisterRepositories(this IServiceCollection services) =>
            services.AddScoped<ITestRepository, TestRepository>()
            .AddScoped<IActionRepository, ActionRepository>();

        public static void RegisterMediator(this IServiceCollection services)
        {
            services.AddScoped<ServiceFactory>(p => type => p.GetService(type));
            services.AddScoped<IMediator, Mediator>();
        }
    }
}
