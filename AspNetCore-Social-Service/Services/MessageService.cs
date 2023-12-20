using AspNetCore_Social_DataAccess.Migrations;
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

		public async Task<List<MessageDto>> GetAllMessage(int userId)
		{			
			var ownerMessages = await _uow.GetRepository<Message>().GetAll(x => x.OwnerUserId == userId , null, x => x.User,x=>x.MessageDetails);
            //var userMessages = await _uow.GetRepository<Message>().GetAll(x => x.UserId == userId, null, x => x.User, x => x.MessageDetails);
            List<Message> messagesList = ownerMessages.Select(x => new Message
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
		public async Task SendMessage(MessageDetailDto message)
		{
			MessageDetail newMessage = _mapper.Map<MessageDetail>(message);
			var meMessage = await _uow.GetRepository<Message>().Get(x => x.Id == message.MessageId);
			var youMessage =  await _uow.GetRepository<Message>().Get(x => x.UserId == meMessage.OwnerUserId && x.OwnerUserId == meMessage.UserId);
			
			try
			{
                await _uow.GetRepository<MessageDetail>().Add(newMessage);
                _uow.Commit();
				newMessage.Id = 0;
                newMessage.MessageId = youMessage.Id;
                await _uow.GetRepository<MessageDetail>().Add(newMessage);
                _uow.Commit();
            }
			catch (Exception)
			{

				throw;
			}
			
		}
		//public async Task<int> StartNewMessage(int targetUserId, int userId)
		//{

		//}
	}
}
