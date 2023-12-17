using AspNetCore_Social_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
	public interface IProfileService
	{
		Task<ProfileDto> GetById(int userId);
		Task<List<PostDto>> GetImagesByUserId(int userId, bool? other);
		Task<List<PostDto>> GetVideosByUserId(int userId, bool? other);
		Task<ProfileFriendsDto> GetFriendsByUserId(int userId);
		Task<UserDto> OtherProfile(int userId);


    }
}
