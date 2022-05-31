using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.Business.Services;
using TodoAppNTier.DataAccess.Contexts;
using TodoAppNTier.DataAccess.UnitOfWork;

namespace TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server = DESKTOP-AG2E4VK; database = TodoDb; integrated security = true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkManager>();
        }
    }
}
