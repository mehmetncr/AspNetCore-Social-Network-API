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

		public MessagesController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet("GetAllMessages")]
		[Authorize]
		public async Task<IActionResult> GetAllMessages()
		{
			var userIdClaim = User.FindFirst(ClaimTypes.UserData);
			if (userIdClaim != null)
			{
				int appUserId = Convert.ToInt32(userIdClaim.Value);
				List<MessageDto> messages= await _messageService.GetAllMessage(appUserId);
				return Ok(messages);
			}
			return BadRequest();
		}
	}
}
