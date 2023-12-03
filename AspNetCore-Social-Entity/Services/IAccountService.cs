﻿using AspNetCore_Social_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
	public interface IAccountService
	{
		Task<string> RegisterAsync(RegisterDto model);
		Task<int> CreateUser(RegisterDto model);
		Task<int> Login(LoginDto model);
		Task LogoutAsync();
	}
}
