using System.Threading.Tasks;

namespace KingICT.Akademija2021.Model.Academy
{
	public interface IAcademyRepository
	{
		Task<Academy> GetAcademyById(int id);
	}
}
