using KingICT.Akademija2021.Model.User;
using KingICT.Akademija2021.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Repository.User
{
	public class UserRepository : IUserRepository
	{
		private readonly AcademyDbContext _dbContext;

		public UserRepository(AcademyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Model.User.User> GetUserByIdAsync(int id)
		{
			return await _dbContext.Set<Model.User.User>()
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();
		}
	}
}
