using KingICT.Akademija2021.Contract.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.WebAPI.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/users"), ApiVersion("1")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
		{
			return Ok(await _userService.GetUserByIdAsync(id));
		}

		[HttpGet("")]
		public async Task<IActionResult> GetUsersAsync()
		{
			return Ok(await _userService.GetUsersAsync());
		}


		[HttpPost("")]
		public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto user)
		{
			try
			{
				return Ok(await _userService.CreateUserAsync(user));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserDto user)
		{
			if (id != user.Id)
			{
				return BadRequest(nameof(user.Id));
			}

			try
			{
				return Ok(await _userService.UpdateUserAsync(user));
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] int id)
		{
			try
			{
				await _userService.DeleteUserByIdAsync(id);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}

			return Ok();
		}
	}
}
