using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IFriendService _friendService;

        public MessagesController(IMessageService messageService, IFriendService friendService)
        {
            _messageService = messageService;
            _friendService = friendService;
        }

        [HttpGet("GetAllMessages")]
        [Authorize]
        public async Task<IActionResult> GetAllMessages()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                MessagesAndFriends list = new MessagesAndFriends()
                {
                    Messages = await _messageService.GetAllMessage(userId),
                    Friends = await _friendService.GetFriends(userId)
                };

                return Ok(list);
            }
            return BadRequest();
        }
        //[HttpPost("StartNewChat")]
        //[Authorize]
        //public async Task<IActionResult> StartNewChat(int targetUserId)
        //{
        //    var userIdClaim = User.FindFirst(ClaimTypes.UserData);
        //    if (userIdClaim != null)
        //    {
        //        int userId = Convert.ToInt32(userIdClaim.Value);

        //    }
        //}
    }
}
