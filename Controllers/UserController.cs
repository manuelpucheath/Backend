using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Interfaces;
using Project.ViewModels;

namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService     _userService;
    private readonly IResponseService _responseService;

    public UserController(IUserService userService, IResponseService responseService)
    {
        _userService     = userService;
        _responseService = responseService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Create([FromBody] UserDto userDto)
    {
        await _userService.CreateAsync(userDto);
        return StatusCode(
            _userService.GetStatusCode(), 
            _responseService.SetResponse(_userService.GetStatusCode(), _userService.GetFunctionMessage()));
    }

    [HttpPost]
    [Route("LogIn")]
    public async Task<ActionResult> LogIn([FromBody] UserDto userDto)
    {
        UserDto data = await _userService.Login(userDto);
        return StatusCode(
            _userService.GetStatusCode(), 
            _responseService.SetResponse(_userService.GetStatusCode(), _userService.GetFunctionMessage(), data));
    }
}