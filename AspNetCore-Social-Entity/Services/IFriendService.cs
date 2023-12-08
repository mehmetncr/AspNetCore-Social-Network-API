using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
	public interface IFriendService
	{
		public Task<List<FriendsDto>> GetFriends(int userId);
		Task<List<FriendsDto>> GetOnlineFriends(int userId);
		Task<List<UserDto>> GetOfferFriends(int userId);
	}
}
