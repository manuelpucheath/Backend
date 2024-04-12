using Microsoft.EntityFrameworkCore;
using Project.Interfaces;
using Project.Models;
using Project.ViewModels;

namespace Project.Services;

public class UserService : IUserService
{

    private int              _statusCode      = 500;
    private string           _functionMessage = "";
    private readonly Context _context;

    public UserService(Context context)
    {
        _context = context;
    }
    
    public async Task CreateAsync(UserDto userDto)
    {
        try
        {
            if(await _context.Users.Where(x => x.UserName == userDto.UserName).AnyAsync())
            {
                _statusCode      = 400;
                _functionMessage = $"A User with the username {userDto.UserName} already exist";
                return;
            }
            User user = new User()
            {
                UserName = userDto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password)
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            _statusCode      = 200;
            _functionMessage = "Success";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UserDto> Login(UserDto userDto)
    {
        try
        {
            User user = await _context.Users
                                      .Where(x => x.UserName == userDto.UserName)
                                      .FirstOrDefaultAsync();
            if (user is null)
            {
                _statusCode      = 404;
                _functionMessage = "Usuario no encontrado";
                return _removeSensitiveDataFromUserDto(userDto);
            }

            if (BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
            {
                _statusCode      = 200;
                _functionMessage = "Usuario Logeado";
                userDto.Id = user.Id;
            }
            else
            {
                _statusCode      = 400;
                _functionMessage = "Usuario o contraseña no coinciden";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return _removeSensitiveDataFromUserDto(userDto);
    }

    private UserDto _removeSensitiveDataFromUserDto(UserDto userDto)
    {
        userDto.Password = null;
        return userDto;
    }

    public int GetStatusCode()
    {
        return _statusCode;
    }

    public string GetFunctionMessage()
    {
        return _functionMessage;
    }
}