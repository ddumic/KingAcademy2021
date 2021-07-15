using KingICT.Akademija2021.Contract.User;
using KingICT.Akademija2021.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IEnumerable<UserDto>> GetUsersAsync()
		{
			var users = await _userRepository.GetUsersAsync();

			return users.Select(x => new UserDto
			{
				FirstName = x.FirstName,
				Id = x.Id,
				LastName = x.LastName
			});
		}

		public async Task<UserDto> CreateUserAsync(CreateUserDto userDto)
		{
			if (string.IsNullOrWhiteSpace(userDto.FirstName))
			{
				throw new ArgumentException(nameof(userDto.FirstName));
			}

			if (string.IsNullOrWhiteSpace(userDto.LastName))
			{
				throw new ArgumentException(nameof(userDto.LastName));
			}

			var userObject = new Model.User.User();
			userObject.SetFirstName(userDto.FirstName);
			userObject.SetLastName(userDto.LastName);

			var user = await _userRepository.CreateUserAsync(userObject);

			return new UserDto
			{
				FirstName = user.FirstName,
				Id = user.Id,
				LastName = user.LastName
			};
		}

		public async Task<UserDto> UpdateUserAsync(UpdateUserDto userDto)
		{
			if (string.IsNullOrWhiteSpace(userDto.FirstName))
			{
				throw new ArgumentException(nameof(userDto.FirstName));
			}

			if (string.IsNullOrWhiteSpace(userDto.LastName))
			{
				throw new ArgumentException(nameof(userDto.LastName));
			}

			var user = await _userRepository.GetUserByIdAsync(userDto.Id);

			if (user is null)
			{
				throw new ArgumentException(nameof(userDto.Id));
			}

			user.SetFirstName(userDto.FirstName);
			user.SetLastName(userDto.LastName);

			await _userRepository.UpdateUserAsync(user);

			return new UserDto
			{
				FirstName = user.FirstName,
				Id = user.Id,
				LastName = user.LastName
			};
		}

		public async Task<bool> DeleteUserByIdAsync(int id)
		{
			var user = await _userRepository.GetUserByIdAsync(id);

			if (user is null)
			{
				throw new ArgumentException(nameof(id));
			}

			await _userRepository.DeleteUserByIdAsync(user);

			return true;
		}
	}
}
