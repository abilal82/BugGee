using BugGee.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugGee.Application.Common.Interfaces
{
   public interface IRoleManager<T> where T : class
    {
        Task<(Result Result, string RoleId)> CreateRoleAsync(T role);

        Task<Result> DeleteRoleAsync(string userId);
    }
}
