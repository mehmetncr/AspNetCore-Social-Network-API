using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Contracts;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[EnableCors]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto model)
		{
			string msg = await _accountService.RegisterAsync(model);
			if (msg == "OK")
			{
				return Ok();
			}
			else
			{
				return BadRequest(msg);
			}

		}
		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginDto model)
		{           
            var user = await _accountService.Login(model);
			if (user == null)
			{
				return NotFound("Kullanıcı adı veya şifre hatalı!");
			}
			return Ok(user);
		}
		[HttpGet("Logout")]
		public async Task<IActionResult> Logout()
		{
			await _accountService.LogoutAsync();
			return Ok();
		}
		[HttpPut("EditPassword")]
		[Authorize]
		public async Task<IActionResult> EditPassword([FromBody] EditPasswordDto model)
		{
			var userIdClaim = User.FindFirst(ClaimTypes.UserData);
			if (userIdClaim != null)
			{
				int appUserId = Convert.ToInt32(userIdClaim.Value);
				model.AppUserId = appUserId;
				string msg = await _accountService.EditUserPassword(model);
				if (msg == "Ok")
				{
					return Ok();
				}
				else if (msg == "WrongUser")
				{
					return NotFound();
				}
			}
			return BadRequest();
		}
	}
}
