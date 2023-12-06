using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
		private readonly SocialContext _socialContext;
		public PostService(IUnitOfWork uow, IFriendService friendService, IMapper mapper, SocialContext socialContext)
		{
			_uow = uow;
			_friendService = friendService;
			_mapper = mapper;
			_socialContext = socialContext;
		}

		public async Task<List<PostDto>> GetAllPostsWithUserId(int userId)
		{
			List<Friends> friends = await _friendService.GetFriends(userId);
			Friends user = new Friends()
			{
				FriendsUserId = userId,
			};
			friends.Add(user);
			var list = await _uow.GetRepository<Post>().GetAll(x => friends.Select(f => f.FriendsUserId).Contains(x.PostUserId), x => x.OrderByDescending(x => x.PostCreateDate), x => x.Comments);
			return _mapper.Map<List<PostDto>>(list);
		}
		public async Task<List<Post>> GetPosts(int userId)
		{
			var posts = _socialContext.Posts.FromSqlRaw($"execute sp_DinamikSorgu {userId}, {10}").Include(x => x.Comments).ToList();
			//var postsss = await _socialContext.Database.SqlQuery<PostsCommentsReplyCommentsDto>($"execute sp_DinamikSorgu {userId}, {10}").ToListAsync();

			return null;
		}
	}
}
