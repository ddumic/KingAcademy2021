using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Model.User
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(int id);

		Task<IEnumerable<User>> GetUsersAsync();

		Task<User> CreateUserAsync(User user);

		Task<User> UpdateUserAsync(User user);

		Task<bool> DeleteUserByIdAsync(User id);
	}
}
