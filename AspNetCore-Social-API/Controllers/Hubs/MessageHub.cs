﻿using AspNetCore_Social_DataAccess.Identity;
using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using AspNetCore_Social_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {
        private readonly IMessageService _messageService;

        public MessageHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public class UserConnection
        {
            public string UserId { get; set; }
            public string ConnectionId { get; set; }
        }
        public static List<UserConnection> OnlineUserConnections { get; set; } = new List<UserConnection>();

      
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            var userId = Context.User?.FindFirstValue(ClaimTypes.Name);
            var connectionId = Context.ConnectionId;
            var existingUser = OnlineUserConnections.FirstOrDefault(user => user.UserId == userId);

            if (existingUser != null)
            {
                existingUser.ConnectionId = connectionId;
            }
            else
            {
                // Eğer kullanıcı yoksa, yeni bir kullanıcı olarak ekle
                UserConnection newUser = new UserConnection()
                {
                    ConnectionId = connectionId,
                    UserId = userId
                };
                OnlineUserConnections.Add(newUser);
            }

           
        }
    


        public async Task MessageSend(string message,string targetUserId,string messageId)
        {
            var userId = Context.User?.FindFirstValue(ClaimTypes.Name);
            UserConnection targetUser = OnlineUserConnections.FirstOrDefault(user => user.UserId == targetUserId);
            MessageDetailDto messageDetail = new MessageDetailDto()
            {
                MessageContent = message,
                OwnerUserId =Convert.ToInt32(userId),
                SendDate = DateTime.Now, 
                MessageId= Convert.ToInt32(messageId)
            };
           await _messageService.SendMessage(messageDetail);
            if (targetUser != null)
            {
                await Clients.Client(targetUser.ConnectionId).SendAsync("ReceivePrivateMessage", userId, message);
            }
            

        }
        public async Task DisconnectOnUnload()
        {

            var userId = Context.User?.FindFirstValue(ClaimTypes.Name);          
            var existingUser = OnlineUserConnections.FirstOrDefault(user => user.UserId == userId);

            if (existingUser != null)
            {
                OnlineUserConnections.Remove(existingUser);
            }          

        }
    }
}