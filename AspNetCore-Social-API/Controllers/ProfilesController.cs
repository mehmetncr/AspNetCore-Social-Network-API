using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProfilesController : ControllerBase
	{
		private readonly IProfileService _profileService;

		public ProfilesController(IProfileService profileService)
		{
			_profileService = profileService;
		}
		
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok( await _profileService.GetById(id));
		}
	}
}
