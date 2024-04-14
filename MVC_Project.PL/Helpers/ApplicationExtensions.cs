﻿using Microsoft.Extensions.DependencyInjection;
using MVC_Project.BLL.Interfaces;
using MVC_Project.BLL.Repositories;

namespace MVC_Project.PL.Helpers
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddAutoMapper(M => M.AddProfile<MappingProfiles>());

            return services;
        }
    }
}