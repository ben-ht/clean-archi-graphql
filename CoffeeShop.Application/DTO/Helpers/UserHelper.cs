using CoffeeShop.Core.Entities;

namespace CoffeeShop.Application.DTO.Helpers;
public static class UserHelper
{
    public static UserDAO ToUser(this UserDto userDto)
    {
        return new()
        {
            Id = userDto.Id,
            UserName = userDto.UserName,
            Password = userDto.Password,
            Email = userDto.Email,
        };
    }
}
