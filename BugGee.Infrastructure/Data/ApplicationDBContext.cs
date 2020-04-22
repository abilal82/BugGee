using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BugGee.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(
           DbContextOptions options
          ) : base(options)
        {
           
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
