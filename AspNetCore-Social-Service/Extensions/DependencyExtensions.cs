using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_DataAccess.Repositories;
using AspNetCore_Social_DataAccess.UnitOfWorks;
using AspNetCore_Social_Entity.Repositories;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AspNetCore_Social_Service.Mapping;
using AspNetCore_Social_Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Extensions
{
	public static class DependencyExtensions
	{
		public static void AddExtensions(this IServiceCollection services)
		{
			services.AddIdentity<AppUser, AppRole>(
			opt =>
			{
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 3;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireDigit = false;

				//opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";

				opt.User.RequireUniqueEmail = true;

				opt.Lockout.MaxFailedAccessAttempts = 3;    //default : 5
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5 dk
			}
			).AddEntityFrameworkStores<SocialContext>();


			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddAutoMapper(typeof(MappingProfile));
			services.AddScoped<IProfileService, ProfileService>();
			services.AddScoped<IPostService, PostService>();
			services.AddScoped<IHomeService, HomeService>();
			services.AddScoped<IFriendService, FriendService>();


		}
	}
}
