using BugGee.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugGee.Application.Common.Interfaces
{

    public interface IUserManager<T> where T : class
    {
        Task<(Result Result, string UserId)> CreateUserAsync(T user, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
