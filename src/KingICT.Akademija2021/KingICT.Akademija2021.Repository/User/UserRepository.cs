using KingICT.Akademija2021.Model.User;
using KingICT.Akademija2021.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

		public async Task<IEnumerable<Model.User.User>> GetUsersAsync()
		{
			return await _dbContext.Set<Model.User.User>()
				.ToListAsync();
		}

		public async Task<Model.User.User> CreateUserAsync(Model.User.User user)
		{
			await _dbContext.Set<Model.User.User>()
				.AddAsync(user);

			await _dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<Model.User.User> UpdateUserAsync(Model.User.User user)
		{
			_dbContext.Set<Model.User.User>()
				.Update(user);

			await _dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<bool> DeleteUserByIdAsync(Model.User.User user)
		{
			_dbContext.Set<Model.User.User>()
				.Remove(user);

			await _dbContext.SaveChangesAsync();

			return true;
		}
	}
}
