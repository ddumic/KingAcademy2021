using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Contract.User
{
	public interface IUserService
	{
		Task<UserDto> GetUserByIdAsync(int id);

		Task<IEnumerable<UserDto>> GetUsersAsync();

		Task<UserDto> CreateUserAsync(CreateUserDto userDto);

		Task<UserDto> UpdateUserAsync(UpdateUserDto userDto);

		Task<bool> DeleteUserByIdAsync(int id);
	}
}
