using AspNetCore_Social_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
	public interface IUserService
	{
        Task<UserDto> GetUserById(int userId);
        Task<string> UpdateUser(UserUpdateDto model);
        Task<UserDto> GetOtherUser(int userId);
        Task TurnOnlineUser(int userId);
        Task TurnOfflineUser(int userId);
    }
}
