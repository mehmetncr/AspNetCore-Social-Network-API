using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IUnitOfWork _uow;
		private readonly IUserService _userService;

        public AccountService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IUnitOfWork uow, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;    
            _userService = userService;
        }

        public async Task LogoutAsync() //Çıkış yapma
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<string> RegisterAsync(RegisterDto model)  //Yeni kullanıcı oluşturma
		{
			string message = string.Empty;

			var appuser = new AppUser()
			{
				UserName = model.UserName,
				Email = model.Email,
				UserId = await this.CreateUser(model)
			};

			var identityResult = await _userManager.CreateAsync(appuser, model.ConfirmPassword);

			if (identityResult.Succeeded)
			{
				message = "OK";

			}
			else
			{
				// eğer appuser kaydı başarısız olursa user tablosundan eklenen kişi silelinecek
			}
			foreach (var error in identityResult.Errors)
			{
				message = error.Description;   //username Email için türkçe hata döndürülecek
			}
			return message;
		}
		public async Task<int> CreateUser(RegisterDto model)
		{

			User user = new User()
			{
				UserFirstName = model.FirstName,
				UserLastName = model.LastName,
				UserGender = model.Gender,
				UserCreatedAt = DateTime.Now,
			};

			await _uow.GetRepository<User>().Add(user);
			await _uow.CommitAsync();

			return user.UserId;
		}

		public async Task<UserDto> Login(LoginDto model)
		{
			var appuser = await _userManager.FindByEmailAsync(model.Email);
			if (appuser != null)
			{
				var signInResult = await _signInManager.PasswordSignInAsync(appuser, model.Password, model.RememberMe, false);
				if (signInResult.Succeeded)
				{
					return await _userService.GetUserById(appuser.UserId);

				}
			}
			return null;
		}

		public async Task<int> GetUserIdByAppUserId(int userId)
		{
            var appuser = await _userManager.FindByIdAsync(userId.ToString());
			return appuser.UserId;
        }
	}
}
