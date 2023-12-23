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

        public async Task<List<NotificationDto>> GetAllNotifications(int userId)
        {
           var notificationList= await _uow.GetRepository<Notification>().GetAll(x => x.NotificationOwnerUserId == userId,null,x=>x.NotificationSenderUser);
            List<NotificationDto> mappedList =  _mapper.Map<List<NotificationDto>>(notificationList);
            return  mappedList;
        }
    }
}
