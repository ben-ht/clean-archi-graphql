using CoffeeShop.Application.DTO;
using CoffeeShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.API;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        try
        {
            return Ok(await _userService.GetById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("")]
    public async Task<IActionResult> Register(UserDto user)
    {
        try
        {
            await _userService.Create(user);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
