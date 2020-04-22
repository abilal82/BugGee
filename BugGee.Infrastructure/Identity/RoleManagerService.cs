using BugGee.Application.Common.Interfaces;
using BugGee.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugGee.Infrastructure.Identity
{
    public class RoleManagerService : IRoleManager<IdentityRole>
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerService(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async Task<(Result Result, string RoleId)> CreateRoleAsync(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(role);

            return (result.ToApplicationResult(), role.Id);
        }

        public async Task<Result> DeleteRoleAsync(string roleId)
        {
            var role =  await _roleManager.FindByIdAsync(roleId);

            if(role != null)
            {
                var result = await DeleteRoleAsync(role);
            }
            return Result.Success();
        }

        public async Task<Result> DeleteRoleAsync(IdentityRole role)
        {
            var result = await _roleManager.DeleteAsync(role);
            return result.ToApplicationResult();
        }

    }
}
