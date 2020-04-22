
using BugGee.Application.Common.Interfaces;
using BugGee.Infrastructure.Data;
using BugGee.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Text;

namespace BugGee.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Services 
            services.AddScoped<IUserManager<ApplicationUser>, UserManagerService>();
            services.AddScoped<IRoleManager<IdentityRole>, RoleManagerService>();


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("BugGeeDatabase")));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();




          //  services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            //  services.AddScoped<ApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            //services.AddAuthentication()
            //    .AddIdentityServerJwt();

            return services;
        }
    }
}
