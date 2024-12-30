using CoffeeShop.Core.Entities;

namespace CoffeeShop.Application.DTO.Helpers;
public static class UserHelper
{
    public static UserDAO ToUser(this UserDto userDto)
    {
        return new()
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Password = userDto.Password,
        };
    }
}
