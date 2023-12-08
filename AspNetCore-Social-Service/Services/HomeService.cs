using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
	public class HomeService : IHomeService
	{
		private readonly IPostService _postService;
		private readonly IFriendService _friendService;
		private readonly IAccountService _accountService;

        public HomeService(IPostService postService, IFriendService friendService, IAccountService accountService)
        {
            _postService = postService;
            _friendService = friendService;
            _accountService = accountService;
        }

        public async Task<HomeDto> GetHome(int userId)
		{
            int id = await _accountService.GetUserIdByAppUserId(userId);
            HomeDto homeDto = new HomeDto();
			homeDto.OnlineFriendsDtos = await _friendService.GetOnlineFriends(id);
			homeDto.OfferUserDtos = await _friendService.GetOfferFriends(id);
			homeDto.PostDtos = await _postService.GetPosts(id, "sp_DinamikSorgu");
			return homeDto;
        }
	}
}
