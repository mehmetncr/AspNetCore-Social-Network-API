using AspNetCore_Social_DataAccess.Context;
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
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public NotificationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<NotificationDto> AddNotification(int senderUserId, int ownerUserId, string notificationType)
        {
            var user = await _uow.GetRepository<User>().GetById(senderUserId);
            
            User senderUser = new User()
            {
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserProfilePicture = user.UserProfilePicture,
                UserId = user.UserId
            };
            
            Notification notification = new Notification();
            notification.NotificationIsSeen = false;
            notification.NotificationOwnerUserId = ownerUserId;
            notification.NotificationSenderUserId = senderUserId;
            notification.NotificationDescription = "Yeni bildirim";
            

            if (notificationType == "Comment")
            {
                notification.NotificationTitle = "Paylaşımınıza yorum yaptı";
            }
            else if (notificationType == "Like")
            {
                notification.NotificationTitle = "Paylaşımınızı beğendi";

            }
            else if(notificationType == "Dislike")
            {
                notification.NotificationTitle = "Paylaşımınızı beğenmedi";
            }
            try
            {
                await _uow.GetRepository<Notification>().Add(notification);
                await _uow.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
            notification.NotificationSenderUser = senderUser;
            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<List<NotificationDto>> GetAllNotifications(int userId)
        {
            var notificationList = await _uow.GetRepository<Notification>().GetAll(x => x.NotificationOwnerUserId == userId, null, x => x.NotificationSenderUser);
            List<NotificationDto> mappedList = _mapper.Map<List<NotificationDto>>(notificationList);
            return mappedList;
        }
    }
}
