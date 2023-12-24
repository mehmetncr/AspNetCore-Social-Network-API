using AspNetCore_Social_DataAccess.Context;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Entity.UnitOfWorks;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> GetAllNotifications(int userId)
        {
            var notificationList = await _uow.GetRepository<Notification>().GetAll(x => x.NotificationOwnerUserId == userId, null, x => x.NotificationSenderUser);
            List<NotificationDto> mappedList = _mapper.Map<List<NotificationDto>>(notificationList);
            return mappedList;
        }
        public async Task<string> AcceptFriendReq(string notificationId)
        {
            try
            {
                var notification = await _uow.GetRepository<Notification>().Get(x => x.NotificationId == Convert.ToInt32(notificationId));
                var friend = await _uow.GetRepository<Friends>().Get(x => x.FriendsUserId == notification.NotificationSenderUserId && x.FriendId == notification.NotificationOwnerUserId);
                friend.FriendsStatus = "approved";
                _uow.GetRepository<Friends>().Update(friend);
                Friends newFriends = new Friends()
                {
                    FriendId = friend.FriendsUserId,
                    FriendsUserId = friend.FriendId,
                    FriendsStatus = "approved"
                };
                await _uow.GetRepository<Friends>().Add(newFriends);
                _uow.GetRepository<Notification>().Delete(notification);
                _uow.Commit();
                return "Ok";

            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public async Task<string> RejectFriendReq(string notificationId)
        {
            try
            {
                var notification = await _uow.GetRepository<Notification>().Get(x => x.NotificationId == Convert.ToInt32(notificationId));
                var friend = await _uow.GetRepository<Friends>().Get(x => x.FriendsUserId == notification.NotificationSenderUserId && x.FriendId == notification.NotificationOwnerUserId);                  
                _uow.GetRepository<Notification>().Delete(notification);
                _uow.GetRepository<Friends>().Delete(friend);
                _uow.Commit();
                return "Ok";

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
