using System.Threading.Tasks;

namespace KingICT.Akademija2021.Model.User
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(int id);
	}
}
