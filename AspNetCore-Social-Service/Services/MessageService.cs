using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
	public class MessageService : IMessageService
	{
		private readonly IAccountService _accountService;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public MessageService(IAccountService accountService, IUnitOfWork uow, IMapper mapper)
		{
			_accountService = accountService;
			_uow = uow;
			_mapper = mapper;
		}

		public async Task<List<MessageDto>> GetAllMessage(int AppUserId)
		{
			int userId = await _accountService.GetUserIdByAppUserId(AppUserId);
			var messages = await _uow.GetRepository<Message>().GetAll(x => x.OwnerUserId == userId, null, x => x.User,x=>x.MessageDetails);
			List<Message> messagesList = messages.Select(x => new Message
			{
				User = new User
				{
					UserFirstName = x.User.UserFirstName,
					UserLastName = x.User.UserLastName,
					UserId = x.User.UserId,
					UserProfilePicture = x.User.UserProfilePicture,
					UserIsOnline = x.User.UserIsOnline
				},			
				Id = x.Id,		
				OwnerUserId = userId,
				MessageDetails= x.MessageDetails.Where(m=>m.MessageId==x.Id).ToList(),
			}).ToList();

             List<MessageDto> mappedList = _mapper.Map<List<MessageDto>>(messagesList);

            return mappedList;
			
			
		}
	}
}
