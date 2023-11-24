﻿using AspNetCore_Social_Entity.DTOs;
using AspNetCore_Social_Entity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Social_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public AccountsController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody]RegisterDto model)
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


	}
}
