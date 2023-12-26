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
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("GetAllNotification")]   //sadece görülmeyenler
        public async Task<IActionResult> GetAllNotification()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                List<NotificationDto> model = await _notificationService.GetAllNotifications(userId);
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpGet("AllNotification")]  //hepsi
        public async Task<IActionResult> AllNotification()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                List<NotificationDto> model = await _notificationService.AllNotifications(userId);
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPost("AcceptFriendReq")]
        public async Task<IActionResult> AcceptFriendReq([FromBody] string notificationId)
        {
            string msg = await _notificationService.AcceptFriendReq(notificationId);
            if (msg == "Ok")
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("RejectReq")]
        public async Task<IActionResult> RejectFriendReq([FromBody] string notificationId)
        {
            string msg = await _notificationService.RejectFriendReq(notificationId);
            if (msg == "Ok")
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("NotificationSeen")]
        public async Task<IActionResult> NotificationSeen()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                int userId = Convert.ToInt32(userIdClaim.Value);
                string msg = await _notificationService.NotificationSeen(userId);
                if (msg == "Ok")
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
