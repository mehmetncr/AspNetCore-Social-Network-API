using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		public ProfilesController(IProfileService profileService, IPostService postService, IFriendService friendService)
		{
			_profileService = profileService;
			_postService = postService;
			_friendService = friendService;
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
	}
}
