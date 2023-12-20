using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IUnitOfWork _uow;
		private readonly IUserService _userService;
		private readonly IAuthService _authService;


        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWork uow, IUserService userService, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
            _userService = userService;
            _authService = authService;
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
				UserEmail = model.Email,
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

                
                    UserDto user = await _userService.GetUserById(appuser.UserId);
					user.AccessToken= _authService.GenereteToken(appuser.UserId.ToString());
					return user;

				}
			}
			return null;
		}

		public async Task<int> GetUserIdByAppUserId(int userId)
		{
            var appuser = await _userManager.FindByIdAsync(userId.ToString());
			return appuser.UserId;
        }

		public async Task<string> EditUserPassword(EditPasswordDto model)
		{
			AppUser user = await _userManager.FindByIdAsync(model.AppUserId.ToString());
			if (user != null)
			{
				var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
				if (result.Succeeded)
				{
					return "Ok";
				}
				else
				{
					return result.Errors.ToString();
				}
			}
			return "WrongUser";
		}

        public async Task<string> ResetUSerPasswordCode(string email)
        {
			string msg = string.Empty;
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null) 
            {

                 string Token = await _userManager.GeneratePasswordResetTokenAsync(user);  //doğrulamak için bir token oluşturulur             


                return Token;
            }
			msg = "Not Found";
			return msg;
        }

		public async Task<string> ResetPassword(ResetPasswordDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
			{
				var result = await _userManager.ResetPasswordAsync(user, model.ReqToken, model.Password);
				if (result.Succeeded)
				{
					return "Ok";
				}
				else
				{
                    return result.Errors.ToString();
                }
				
			}
			return string.Empty;
		}

        public async Task<List<UserDto>> GetAllUsers()
        {
			try
			{
				List<UserDto> newUsers = new List<UserDto>();
                var users = await _uow.GetRepository<User>().GetAll();
				foreach (var item in users)
				{
					UserDto userDto = new UserDto()
					{
						UserId = item.UserId,
						UserFirstName = item.UserFirstName,
						UserLastName = item.UserLastName,
						UserProfilePicture = item.UserProfilePicture,
					};
					newUsers.Add(userDto);
				}
                return newUsers;
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
