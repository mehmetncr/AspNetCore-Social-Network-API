using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Entities;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Claims;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class ProfilesController : ControllerBase
	{
		private readonly IProfileService _profileService;
		private readonly IPostService _postService;
		private readonly IFriendService _friendService;
		private readonly IUserService _userService;
		private readonly IInterestService _interestService;

        public ProfilesController(IProfileService profileService, IPostService postService, IFriendService friendService, IUserService userService, IInterestService interestService)
        {
            _profileService = profileService;
            _postService = postService;
            _friendService = friendService;
            _userService = userService;
            _interestService = interestService;
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok( await _profileService.GetById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
		}

		[HttpGet("Images")]
		public async Task<IActionResult> GetImages()
		{
			return Ok(await _profileService.GetImagesByUserId(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
		}
		[HttpGet("Videos")]
		public async Task<IActionResult> GetVideos()
		{
			return Ok(await _profileService.GetVideosByUserId(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
		}
		[HttpGet("Friends")]
		public async Task<IActionResult> GetFriends()
		{
			return Ok(await _profileService.GetFriendsByUserId(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
		}
		[HttpPut("update")]
		public async Task<IActionResult> PostUpdate([FromBody] UserUpdateDto model)
		{
			if(User.Identity.IsAuthenticated)
			{
                model.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                string msg = await _userService.UpdateUser(model);
                if (msg == "Ok")
                {
                    return Ok( await _userService.GetUserById(model.UserId));
                }
                return BadRequest(msg);
            }

           return Unauthorized();
        }
		[HttpPost("AddInterest")]
		public async Task<IActionResult> InterestUpdate([FromBody] string interest)
		{
			var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));   // app userdan normal usera geçilecek

            Interest newInterest = new Interest()
			{
				InterestName=interest,
				UserId=userId
            };

			string msg = await _interestService.AddInterest(newInterest);
			if (msg == "Ok")
			{
                return Ok(await _userService.GetUserById(userId));
            }
			return BadRequest(msg);
		}
	}
}
