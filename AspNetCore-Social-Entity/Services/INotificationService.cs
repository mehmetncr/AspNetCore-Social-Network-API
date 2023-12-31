﻿using AspNetCore_Social_Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Social_Entity.Services
{
    public  interface INotificationService
    {
        Task<List<NotificationDto>> GetAllNotifications(int userId);
        Task<NotificationDto> AddNotification(int senderUserId, int ownerUserId, string notificationType , string postId);
        Task<string> AcceptFriendReq(string notificationId);
        Task<string> RejectFriendReq(string notificationId);
        Task<string> NotificationSeen(int userId);
        Task<List<NotificationDto>> AllNotifications(int userId);
    }
}
