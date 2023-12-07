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
	public class FriendService : IFriendService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public FriendService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<List<Friends>> GetFriends(int userId)
		{
			var list = await _uow.GetRepository<Friends>().GetAll(x=>x.FriendsUserId == userId);
			return list.ToList();
		}
		public async Task<List<FriendsDto>> GetOnlineFriends(int userId)
		{
			var userFriends = await _uow.GetRepository<Friends>().GetAll(x => x.FriendsUserId == userId && x.Friend.UserIsOnline == true, null, x=>x.Friend);
			return _mapper.Map<List<FriendsDto>>(userFriends);
		}
		public async Task<List<UserDto>> GetOfferFriends(int userId)
		{
			//arkadaşların arkadaşları çekilecek önerilen arkadaş olarak
			var friends = await _uow.GetRepository<User>().GetAll();
			friends.Take(10);
			
			return _mapper.Map<List<UserDto>>(friends);
		}
	}
}
