using KingICT.Akademija2021.Contract.User;
using Microsoft.AspNetCore.Mvc;
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
		public async Task<IActionResult> GetUserByIdAsync(int id)
		{
			return Ok(await _userService.GetUserByIdAsync(id));
		}
	}
}
