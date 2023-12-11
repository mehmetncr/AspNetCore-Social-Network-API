using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomesController : ControllerBase
	{
		private readonly IHomeService _homeService;
		private readonly IFriendService _friendService;

		public HomesController(IHomeService homeService, IFriendService friendService)
		{
			_homeService = homeService;
			_friendService = friendService;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetHome() 
		{
            var userIdClaim = User.FindFirst(ClaimTypes.UserData);
            if (userIdClaim != null)
            {
                var userId = userIdClaim.Value; 
                var value = await _homeService.GetHome(Convert.ToInt32(userId));
                return Ok(value);
            }
			return BadRequest();

		
		}
	}
}
