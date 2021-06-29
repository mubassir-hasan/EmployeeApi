using EmployeeMgt.Application.Emloyees;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeMgt.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEmployeeService, EmployeeService>(); ;
            return services;
        }
    }
}
