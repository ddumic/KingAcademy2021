using KingICT.Akademija2021.Contract.User;
using KingICT.Akademija2021.Model.User;
using System.Threading.Tasks;

namespace KingICT.Akademija2021.Service.User
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> GetUserByIdAsync(int id)
		{
			var user = await _userRepository.GetUserByIdAsync(id);

			return new UserDto
			{
				FirstName = user.FirstName,
				Id = user.Id,
				LastName = user.LastName
			};
		}
	}
}
