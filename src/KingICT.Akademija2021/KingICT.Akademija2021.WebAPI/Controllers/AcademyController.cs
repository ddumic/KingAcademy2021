using KingICT.Akademija2021.Contract.Academy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.WebAPI.Controllers
{
	[ApiController, Route("api/v{version:apiVersion}/academies"), ApiVersion("1")]
	public class AcademyController : ControllerBase
	{
		private readonly IAcademyService _academyService;

		public AcademyController(IAcademyService academyService)
		{
			_academyService = academyService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAcademyById(int id)
		{
			return Ok(await _academyService.GetAcademyById(id));
		}
	}
}
