using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
	public class PostService : IPostService
	{
		private readonly IUnitOfWork _uow;
		private readonly IFriendService _friendService;
		private readonly IMapper _mapper;
		public PostService(IUnitOfWork uow, IFriendService friendService, IMapper mapper)
		{
			_uow = uow;
			_friendService = friendService;
			_mapper = mapper;
		}

		public async Task<List<PostDto>> GetAllPostsWithUserId(int userId)
		{
			List<Friends> friends = await _friendService.GetFriends(userId);
			Friends user = new Friends()
			{
				FriendsUserId = userId,
			};
			friends.Add(user);
			var list = await _uow.GetRepository<Post>().GetAll(x => friends.Select(f => f.FriendsUserId).Contains(x.UserId),x=>x.OrderByDescending(x=>x.CreateDate), x => x.Comments);
			return _mapper.Map<List<PostDto>>(list);
		}
	}
}
