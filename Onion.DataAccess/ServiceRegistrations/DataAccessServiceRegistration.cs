using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Core.Entities;
using Onion.DataAccess.Abstractions;
using Onion.DataAccess.Context;
using Onion.DataAccess.DataInitializers;
using Onion.DataAccess.Interceptor;
using Onion.DataAccess.Repositories.Abstractions;
using Onion.DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContextInitializer, DbContextInitializer>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {

                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;

            }).AddDefaultTokenProviders()
       .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<BaseAuditableInterceptor>();

            return services;
        }
    }
}
