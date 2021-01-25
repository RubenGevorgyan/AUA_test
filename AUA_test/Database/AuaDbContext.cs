using AUA_test.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AUA_test
{
    public class AuaDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuaDbContext() : base("Default")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<UserClasses> UserClasses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
    }
}