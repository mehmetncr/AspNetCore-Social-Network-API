using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomesController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get() 
		{
			return Ok();
		}
	}
}
