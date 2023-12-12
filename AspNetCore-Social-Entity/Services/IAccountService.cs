using AspNetCore_Social_Entity.DTOs;
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
		Task<UserDto> Login(LoginDto model);
		Task LogoutAsync();
		Task<int> GetUserIdByAppUserId(int userId);
		Task<string> EditUserPassword(EditPasswordDto model);
		Task<string> ResetUSerPasswordCode(string email);
		Task<string> ResetPassword(ResetPasswordDto model);

    }
}
