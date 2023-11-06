using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_DataAccess.Context
{
    public class SocialContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public SocialContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PrivacySettings> PrivacySettings { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
    }
}
