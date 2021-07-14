using KingICT.Akademija2021.Contract.Academy;
using KingICT.Akademija2021.Model.Academy;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Service.Academy
{
	public class AcademyService : IAcademyService
	{
		private readonly IAcademyRepository _academyRepository;

		public AcademyService(IAcademyRepository academyRepository)
		{
			_academyRepository = academyRepository;
		}

		public async Task<AcademyDto> GetAcademyById(int id)
		{
			var academy = await _academyRepository.GetAcademyById(id);

			return new AcademyDto
			{
				AcademyName = academy.AcademyName,
				Id = academy.Id
			};
		}
	}
}
