using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
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
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PrivacySettings> PrivacySettings { get; set; }
        public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Friends> Friends { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<ReplyComment> ReplyComments { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>()
				.HasOne(u => u.PrivacySettings)
				.WithOne(p => p.User)
				.HasForeignKey<PrivacySettings>(p => p.UserId);

			builder.Entity<Comment>()
			.HasOne(c => c.User)
			.WithMany(u => u.Comments)
			.HasForeignKey(c => c.UserId)  // Foreign key olarak UserId'yi kullan
			.OnDelete(DeleteBehavior.ClientSetNull);

			builder.Entity<ReplyComment>()
			.HasOne(c => c.User)
			.WithMany(u => u.ReplyComments)
			.HasForeignKey(c => c.UserId)  // Foreign key olarak UserId'yi kullan
			.OnDelete(DeleteBehavior.ClientSetNull);



			base.OnModelCreating(builder);
		}
	}
}
