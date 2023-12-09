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
		Task<List<PostDto>> GetImagesByUserId(int userId);
		Task<List<PostDto>> GetVideosByUserId(int userId);
		Task<ProfileFriendsDto> GetFriendsByUserId(int userId);

	}
}
