using CoffeeShop.Core.Entities;

namespace CoffeeShop.Application.DTO;
public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public UserDto() { }

    public UserDto(UserDAO user)
    {
        Id = user.Id;
        Username = user.Username;
        Password = user.Password;
    }
}
