using KingICT.Akademija2021.Model.Academy;
using KingICT.Akademija2021.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Repository.Academy
{
	public class AcademyRepository : IAcademyRepository
	{
		private readonly AcademyDbContext _dbContext;

		public AcademyRepository(AcademyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Model.Academy.Academy> GetAcademyById(int id)
		{
			return await _dbContext.Set<Model.Academy.Academy>()
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();
		}
	}
}
