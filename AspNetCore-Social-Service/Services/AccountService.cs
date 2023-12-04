﻿using AspNetCore_Social_DataAccess.Identity;
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
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		private readonly IProfileService _profileService;

		public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IUnitOfWork uow, IMapper mapper, IProfileService profileService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_uow = uow;
			_mapper = mapper;
			_profileService = profileService;
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
				FirstName = model.FirstName,
				LastName = model.LastName,
				Gender = model.Gender,
				CreatedAt = DateTime.Now,
			};

			await _uow.GetRepository<User>().Add(user);
			await _uow.CommitAsync();

			return user.Id;
		}

		public async Task<UserDto> Login(LoginDto model)
		{
			var appuser = await _userManager.FindByEmailAsync(model.Email);
			if (appuser != null)
			{
				var signInResult = await _signInManager.PasswordSignInAsync(appuser, model.Password, model.RememberMe, false);
				if (signInResult.Succeeded)
				{
					return await _profileService.GetById(appuser.UserId);

				}
			}
			return null;
		}

	}
}
