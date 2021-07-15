using System.Threading.Tasks;

namespace KingICT.Akademija2021.Contract.User
{
	public interface IUserService
	{
		Task<UserDto> GetUserByIdAsync(int id);
	}
}
