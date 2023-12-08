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

		public ProfilesController(IProfileService profileService, IPostService postService)
		{
			_profileService = profileService;
			_postService = postService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok( await _profileService.GetById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
		}	
	}
}
