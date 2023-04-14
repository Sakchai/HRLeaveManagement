using System;
using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
           
            var assemlies = AppDomain.CurrentDomain.GetAssemblies();//Assembly.GetExecutingAssembly();
            assemlies = assemlies.Where(a => a.GetName().Name.Contains("HR.LeaveManagement.Infrastructure") ||
            a.GetName().Name.Contains("HR.LeaveManagement.Persistence") || a.GetName().Name.Contains("HR.LeaveManagement.Identity")
            ).ToArray();
            services.AddAutoMapper(assemlies);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
