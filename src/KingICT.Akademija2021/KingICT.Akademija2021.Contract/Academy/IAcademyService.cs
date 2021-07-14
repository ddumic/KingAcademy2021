using System.Threading.Tasks;

namespace KingICT.Akademija2021.Contract.Academy
{
	public interface IAcademyService
	{
		Task<AcademyDto> GetAcademyById(int id);
	}
}
