using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
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

		public FriendService(IUnitOfWork uow)
		{
			_uow = uow;
		}

		public async Task<List<Friends>> GetFriends(int userId)
		{
			var list = await _uow.GetRepository<Friends>().GetAll(x=>x.UserId == userId);
			return list.ToList();
		}
	}
}
