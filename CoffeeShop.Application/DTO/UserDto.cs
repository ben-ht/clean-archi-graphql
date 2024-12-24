using CoffeeShop.Core.Entities;

namespace CoffeeShop.Application.DTO;
public class UserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDto(UserDAO user)
    {
        Id = user.Id;
        UserName = user.UserName;
        Email = user.Email;
        Password = user.Password;
    }
}
