using CoffeeShop.Application.DTO;
using CoffeeShop.Application.DTO.Helpers;
using CoffeeShop.Core.Interfaces;

namespace CoffeeShop.Application.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Create(UserDto userDto)
    { 
        await _userRepository.Create(userDto.ToUser());
    }

    public async Task<UserDto> GetById(int id)
    {
        return new UserDto(await _userRepository.GetById(id));
    }
}
