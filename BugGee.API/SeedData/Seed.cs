using BugGee.Infrastructure;
using BugGee.Infrastructure.Data;
using BugGee.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugGee.API.SeedData
{
    public static class Seed
    {
        private static  string[] roles = { "Super Admin", "Admin", "User" };
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            byte count = 0;
            string userPASS = "@Ailal786";

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManger = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
          

            var userMangerService = new UserManagerService(userManger);
            var roleManagerSerice = new RoleManagerService(roleManager);

            //var conetextIfExist =  context.Database.EnsureCreated();
            // var context = ApplicationDbContext.Create();


            if (!context.Roles.Any())
            {
                foreach (var role in roles)
                {
                    await roleManagerSerice.CreateRoleAsync(new IdentityRole() { Name = role});
                }
            } 

            if (!context.Users.Any())
            {

                var userList = new List<ApplicationUser>() {
                             new ApplicationUser()
                            {
                                FirstName = "Bilal",
                                LastName = "Aslam",
                                UserName = "abilal82",
                                Email = "abilal.82@gmail.com",
                                PhoneNumber = "03464131733"
                            },
                            new ApplicationUser()
                            {
                                FirstName = "Abdul Rehman",
                                LastName = "Ahsan",
                                UserName = "aghazi82",
                                Email = "aghazi.82@gmail.com",
                                PhoneNumber = "03464131733"
                            },
                                new ApplicationUser()
                            {
                                FirstName = "Waleed",
                                LastName = "Ahsan",
                                UserName = "awaleed82",
                                Email = "awaleed.82@gmail.com",
                                PhoneNumber = "03464131733"
                            }

                };

                foreach (var user in userList)
                {
                   await  userMangerService.CreateUserAsync(user, userPASS);
                    await userMangerService.AssignRoleAsync(user.Id,roles[count++]);

                }
                
            }



        }

       
    }
}
